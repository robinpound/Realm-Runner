using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Walking : MonoBehaviour
{
    [Header("Don't Touch!")]    
    [SerializeField] private NavMeshAgent agent; 
    [SerializeField] private Transform player; 
    [SerializeField] private LayerMask whatIsGround, whatIsPlayer;

    [Header("Settings")]    
    [SerializeField] private float waypointRange;
    [SerializeField] private float chaseRange;
    [SerializeField] private float attackRange;
    [SerializeField] private float timeBetweenAttacks; 
    [SerializeField] private float patrolSpeed = 0.5f;
    [SerializeField] private float chaseSpeed = 1f;
    [SerializeField] private float attackSpeed = 1.5f;
    
    [Header("Behind the scenes:")] 
    [SerializeField] private Vector3 waypoint; 
    [SerializeField] private bool isWaypointSet = false;
    [SerializeField] private bool isplayerInChaseRange = false;
    [SerializeField] private bool isplayerInAttackRange = false;
    [SerializeField] private bool isattacked = false; 

    void Awake() 
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void FixedUpdate() {
        isplayerInChaseRange = Physics.CheckSphere(transform.position, chaseRange, whatIsPlayer);
        isplayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!isplayerInChaseRange && !isplayerInAttackRange) Patrol(); 
        if (isplayerInChaseRange && !isplayerInAttackRange) Chase(); 
        if (isplayerInChaseRange && isplayerInAttackRange) Attack(); 
    }
    
    private void Patrol()
    {
        agent.speed = patrolSpeed;
        if(!isWaypointSet) FindWayPoint(); 
        if(Random.Range(0,100) == 1) FindWayPoint();

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
        }
    }

    private void Chase()
    {
        agent.speed = chaseSpeed;
        Vector3 playerposition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        agent.SetDestination(player.transform.position);
    }

    private void Attack()
    {
        agent.speed = attackSpeed;
        agent.SetDestination(transform.position); //Stop moving
        transform.LookAt(player);

        if(!isattacked)
        {
            /*
                ATTACK CODE HERE!
            */
            Debug.Log("BANG!");
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
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawSphere(waypoint, 0.5f);

    }
}
