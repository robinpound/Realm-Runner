using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Walking : MonoBehaviour
{
    public NavMeshAgent agent; 
    public Transform player; 
    public LayerMask whatIsGround, whatIsPlayer;

    [Header("Patroling")]    
    public Vector3 waypoint; 
    [SerializeField] bool _isWaypointSet;
    public float waypointRange;

    [Header("Attacking")]    
    public float timeBetweenAttacks; 
    [SerializeField] bool _attacked;

    [Header("Attacking")]   
    public float alertRange, attackRange;
    public bool isplayerInAlertRange, isplayerInAttackRange;

    void Awake() 
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate() {
        isplayerInAlertRange = Physics.CheckSphere(transform.position, alertRange, whatIsPlayer);
        isplayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!isplayerInAlertRange && !isplayerInAttackRange) Patrol();
        if (!isplayerInAlertRange && isplayerInAttackRange) Chase();
        if (isplayerInAlertRange && isplayerInAttackRange) Attack();
    }
    
    private void Patrol()
    {
        if(!_isWaypointSet) FindWalkPoint();

        if(_isWaypointSet)
            agent.SetDestination(waypoint);

        //Check if reached waypoint
        Vector3 distanceToWalkPoint = transform.position - waypoint;
        Debug.Log(distanceToWalkPoint);
        if (distanceToWalkPoint.magnitude < 1f)
            _isWaypointSet = false;
    }

    private void FindWalkPoint()
    {
        float randomZ = Random.Range(-waypointRange, waypointRange);
        float randomX = Random.Range(-waypointRange, waypointRange);
        float currentZ = transform.position.z;
        float currentX = transform.position.x;
        
        waypoint = new Vector3 (currentX + randomX, transform.position.y, currentZ + randomZ);

        //check if place is valid
        if(Physics.Raycast(waypoint, -transform.up, 2f, whatIsGround))
            _isWaypointSet = true;

    }

    private void Chase()
    {
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        agent.SetDestination(transform.position); // stop moving
        transform.LookAt(player);

        if(!_attacked)
        {
            /*
                ATTACK CODE HERE!
            */
            _attacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack() {
        _attacked = false;
    }

}
