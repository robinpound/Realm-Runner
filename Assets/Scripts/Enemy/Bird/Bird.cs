using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bird : MonoBehaviour
{
    private Rigidbody rb;
    private Transform player; 

    [Header("Behind The Scenes:")] 
    [SerializeField] private bool isplayerInCircleRange = false;
    [SerializeField] private bool isplayerInAttackRange = false;
    [SerializeField] private Vector3 waypoint; 
    [SerializeField] private bool isWaypointSet = false;

    [Header("Settings:")] 
    [SerializeField] private float circleSightRange = 25f;
    [SerializeField] private float circleSpeed;
    [SerializeField] private float circleHeight = 10f;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float attackRange;

    [Header("Layers")] 
    [SerializeField] private LayerMask whatIsPlayer;

    [Header("Patrol:")] 
    [SerializeField] GameObject patrolPoint;
    [SerializeField] float patrolPointRange;
    [SerializeField] float patrolSpeedmultiplier = 0.2f;
    [SerializeField] float patrolwaypointacceptaceRadius = 10f;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate() 
    {
        float disctance = (player.position - transform.position).magnitude;

        isplayerInCircleRange = Physics.CheckSphere(transform.position, circleSightRange, whatIsPlayer);
        Debug.Log("isplayerInCircleRange:" + isplayerInCircleRange);
        isplayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!isplayerInCircleRange && !isplayerInAttackRange) Patrol(); 
        if (isplayerInCircleRange && !isplayerInAttackRange) Circle(); 
        if (isplayerInCircleRange && isplayerInAttackRange) Attack(); 
    }

    private void Patrol()
    {
        if(!isWaypointSet) FindWayPoint(); 
        if(isWaypointSet) 
        {
            transform.LookAt(waypoint);
            rb.AddRelativeForce(Vector3.forward * patrolSpeedmultiplier, ForceMode.Force);
        }
        
        WayPointReachedCheck();
    }

    private void FindWayPoint()
    {
        float randomZ = Random.Range(-patrolPointRange, patrolPointRange);
        float randomX = Random.Range(-patrolPointRange, patrolPointRange);
        float currentYYZ = patrolPoint.transform.position.z;
        float currentYYX = patrolPoint.transform.position.x;
        float currentPPY = patrolPoint.transform.position.y;

        waypoint = new Vector3 (currentYYX + randomX, currentPPY, currentYYZ + randomZ);
        isWaypointSet = true;
    }

    private void WayPointReachedCheck()
    {
        Vector3 distanceToWalkPoint = transform.position - waypoint;
        if (distanceToWalkPoint.magnitude < patrolwaypointacceptaceRadius)
            isWaypointSet = false;
    }

    private void Circle()
    {
        transform.LookAt(player);
    }

    private void Attack()
    {
        
    }

    private void OnDrawGizmosSelected() {
        
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(patrolPoint.transform.position, patrolPointRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, circleSightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(waypoint, 1f);
        if (!isplayerInCircleRange && !isplayerInAttackRange)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(waypoint, patrolwaypointacceptaceRadius);
        }
    }
}
