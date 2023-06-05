using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Walking : MonoBehaviour
{
    [Header("Attacking")]    
    [SerializeField] private NavMeshAgent agent; 
    [SerializeField] private Transform player; 
    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;

    [Header("Settings")]    
    [SerializeField] private float waypointRange;
    [SerializeField] private float alertRange;
    [SerializeField] private float attackRange;
    [SerializeField] private float timeBetweenAttacks; 
 
    private Vector3 waypoint; 
    private bool isWaypointSet;
    private bool isplayerInAlertRange;
    private bool isplayerInAttackRange;
    private bool isattacked; 

    void Awake() 
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate() {
        isplayerInAlertRange = Physics.CheckSphere(transform.position, alertRange, whatIsGround);
        isplayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!isplayerInAlertRange && !isplayerInAttackRange) Patrol();
        if (!isplayerInAlertRange && isplayerInAttackRange) Chase();
        if (isplayerInAlertRange && isplayerInAttackRange) Attack();
    }
    
    private void Patrol()
    {
        Debug.Log("Patrolling: " + isWaypointSet);
        if(!isWaypointSet) FindWayPoint();

        if(isWaypointSet)
            agent.SetDestination(waypoint);

        //Check if reached waypoint
        Vector3 distanceToWalkPoint = transform.position - waypoint;
        if (distanceToWalkPoint.magnitude < 1f)
            isWaypointSet = false;
    }

    private void FindWayPoint()
    {
        float randomZ = Random.Range(-waypointRange, waypointRange);
        float randomX = Random.Range(-waypointRange, waypointRange);
        float currentZ = transform.position.z;
        float currentX = transform.position.x;
        
        waypoint = new Vector3 (currentX + randomX, transform.position.y, currentZ + randomZ);
        //check if place is valid
        
        if(Physics.Raycast(waypoint, -transform.up, 2f, whatIsGround)){
            isWaypointSet = true;
            Debug.Log("found waypoint");
        }
    }

    private void Chase()
    {
        Debug.Log("Chasing");
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        Debug.Log("Attacking");
        agent.SetDestination(transform.position); //Stop moving
        transform.LookAt(player);

        if(!isattacked)
        {
            /*
                ATTACK CODE HERE!
            */
            isattacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack() {
        isattacked = false;
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, waypointRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, alertRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawSphere(waypoint, 0.5f);

    }
}
