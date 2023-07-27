using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniboss : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject player;

    miniboss_ref references;

    float pathUpdateDeadLine;
    float attackDeadLine;
    float healDeadLine;

    float alertDistance;
    float shootingDistance;

    
    private float healingMinHealth = 30;
    private EnemyHealth health;

    public GameObject missile;
    public GameObject spawnpoint;

    [SerializeField] private bool isDoingSomething = false;

    
    
    private enum EnemyState
    {
        waiting, 
        MovingTo,
        Shooting,
        Healing
    }

    [SerializeField] private EnemyState currentState;

    private void Awake() {
        references = GetComponent<miniboss_ref>();
        health = GetComponent<EnemyHealth>();
    }

    private void Start() {
        alertDistance = references.alertDistance; //transfer these
        shootingDistance = references.shootingDistance; //transfer these
        currentState = EnemyState.waiting;
    }

    private void FixedUpdate() {

        //bool needsHealing = temporaryHealth < 25; // CHANGE-TO: randomiser + if (references.health.healthpoints <= (totalhealth * 0.2))
        //bool needsLeaping = temporaryHealth < 50; // CHANGE-TO: randomiser + ... ???

        bool isLowHealth = health.GetCurrentHealth() < healingMinHealth;
        bool inAlertRange = Vector3.Distance(transform.position, playerTransform.position) <= alertDistance;
        bool inShootRange = Vector3.Distance(transform.position, playerTransform.position) <= shootingDistance;
        
        //Debug.Log(inAlertRange + " : " + alertDistance + " --- Distance:" + Vector3.Distance(transform.position, playerTransform.position));
        
        if (inAlertRange & !isDoingSomething) currentState = EnemyState.MovingTo;
        if (inShootRange & !isDoingSomething) currentState = EnemyState.Shooting;
        if (isDoingSomething) currentState = EnemyState.waiting; 
            
        if (isLowHealth) Heal(); 
        
        switch (currentState)
        {
            case EnemyState.waiting:
                references.navMA.SetDestination(transform.position);
                break;
            case EnemyState.MovingTo:
                LookAtPlayer();
                UpdateNavPath();
                break;
            case EnemyState.Shooting:
                LookAtPlayer();
                Shoot();
                break;
            case EnemyState.Healing:
                Heal(); 
                break;
        }        
    }

    private void UpdateNavPath(){
        // NavMesh Delay optimisation 
        if(Time.time >= pathUpdateDeadLine) 
        {
            pathUpdateDeadLine = Time.time + references.pathUpdateDelay;
            
        }
        references.navMA.SetDestination(playerTransform.position);
    }

    private void LookAtPlayer() {
        Vector3 lookPosition = playerTransform.position - transform.position;
        lookPosition.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    private void Shoot()
    {
        if (Time.time >= attackDeadLine)
        {
            Instantiate(missile, spawnpoint.transform.position, Quaternion.identity);
            references.navMA.SetDestination(transform.position);
            attackDeadLine = Time.time + references.attackDelay;
        }
    }

    private void Heal(){
        isDoingSomething = true;
        if(Time.time >= healDeadLine)
        {
            references.ps.Play();
            health.AddCurrentHealth(15);
            healingMinHealth -= 5;
            healDeadLine = Time.time + references.healDelay;
            Invoke(nameof(ResetDoing), references.healDelay);
        }
    }
    
    private void ResetDoing() => isDoingSomething = false;

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue; Gizmos.DrawWireSphere(transform.position, alertDistance);
        Gizmos.color = Color.red;  Gizmos.DrawWireSphere(transform.position, shootingDistance);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("HIT by somehting");
        health.TakeDamage(10);
    }
}