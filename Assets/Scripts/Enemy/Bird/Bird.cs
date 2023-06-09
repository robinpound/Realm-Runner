using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bird : MonoBehaviour
{
    private Rigidbody rb;
    private Transform player; 

    [Header("Alerted!:")] 
    [SerializeField] private float attackRange;
    [SerializeField] private float delayBeforeReset;
    [SerializeField] private float alertSightRange;
    [SerializeField] private float alertSpeed;
    [SerializeField] private float escapeSpeed;

    private bool isplayerInAlertRange = false;
    private bool isplayerInAttackRange = false;
    [SerializeField] private bool justAttacked = false;
    

    [Header("Layers")] 
    [SerializeField] private LayerMask whatIsPlayer;

    [Header("Patrolling!:")] 
    [SerializeField] GameObject patrolPoint;
    [SerializeField] float patrolPointRange; 
    [SerializeField] float patrolSpeedmultiplier;
    [SerializeField] float patrolwaypointAcceptaceRadius; 
    private Vector3 waypoint; 
    private bool isWaypointSet = false;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate() 
    {
        float disctance = (player.position - transform.position).magnitude;

        isplayerInAlertRange = Physics.CheckSphere(transform.position, alertSightRange, whatIsPlayer);
        isplayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!isplayerInAlertRange) Patrol(); 
        if (isplayerInAlertRange) MoveToPlayer(); 

    }

    private void Patrol()
    {
        justAttacked = false;
        if(!isWaypointSet) FindWayPoint(); 
        if(isWaypointSet) 
        {
            transform.LookAt(waypoint);
            rb.AddRelativeForce(Vector3.forward * patrolSpeedmultiplier, ForceMode.Force);
            
            //rb.AddForceAtPosition(Vector3.forward * patrolSpeedmultiplier, transform.position, ForceMode.Force);
        }
        
        WayPointReachedCheck();
    }

    private void FindWayPoint()
    {
        float randomZ = Random.Range(-patrolPointRange, patrolPointRange);
        float randomX = Random.Range(-patrolPointRange, patrolPointRange);

        Vector3 currentPos = patrolPoint.transform.position;
        waypoint = new Vector3(currentPos.x + randomX, currentPos.y, currentPos.z + randomZ);
        isWaypointSet = true;
    }

    private void WayPointReachedCheck()
    {
        Vector3 distanceToWalkPoint = transform.position - waypoint;
        if (distanceToWalkPoint.magnitude < patrolwaypointAcceptaceRadius)
        {
            isWaypointSet = false;
        }
    }

    private void MoveToPlayer()
    {  
        transform.LookAt(player);    
        if (!isplayerInAttackRange && !justAttacked) //move towards player
        {
            rb.AddRelativeForce(Vector3.forward * alertSpeed, ForceMode.Force);
            Invoke(nameof(Escape), delayBeforeReset);
        }
        if (isplayerInAttackRange) 
        {
            Debug.Log("HIT!");
            Escape();
        }
    }

    private void Escape()
    {
        justAttacked = true;
        rb.AddForce(Vector3.up * escapeSpeed);
        Invoke(nameof(ResetAttack), delayBeforeReset);
    }
    
    private void ResetAttack() => justAttacked = false;

    private void OnDrawGizmosSelected() {
        
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(patrolPoint.transform.position, patrolPointRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, alertSightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(waypoint, 1f);
        if (!isplayerInAlertRange && !isplayerInAttackRange)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(waypoint, patrolwaypointAcceptaceRadius);
        }
    }
}
