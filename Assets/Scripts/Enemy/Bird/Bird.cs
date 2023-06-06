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
        FindWayPoint();
    }

    private void FindWayPoint()
    {
        float randomZ = Random.Range(-patrolPointRange, patrolPointRange);
        float randomX = Random.Range(-patrolPointRange, patrolPointRange);
        float currentZ = transform.position.z;
        float currentX = transform.position.x;
        float currentPPY = patrolPoint.transform.position.y;

        waypoint = new Vector3 (currentX + randomX, currentPPY, currentZ + randomZ);
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
    }
}
