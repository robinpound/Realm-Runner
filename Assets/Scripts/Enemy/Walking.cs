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
        Debug.Log("Patrolling");
        if(!_isWaypointSet) FindWalkPoint();

        if(_isWaypointSet)
            agent.SetDestination(waypoint);

        //Check if reached waypoint
        Vector3 distanceToWalkPoint = transform.position - waypoint;
        Debug.Log("distanceToWalkPoint:" + distanceToWalkPoint);
        Debug.Log("distanceToWalkPoint.magnitude:" + distanceToWalkPoint.magnitude);

        if (distanceToWalkPoint.magnitude < 1f)
            Debug.Log("SetToFalse");
            _isWaypointSet = false;
    }

    private void FindWalkPoint()
    {
        float randomZ = Random.Range(-waypointRange, waypointRange);
        float randomX = Random.Range(-waypointRange, waypointRange);
        float currentZ = transform.position.z;
        float currentX = transform.position.x;
        
        waypoint = new Vector3 (currentX + randomX, transform.position.y, currentZ + randomZ);
        Debug.Log("waypoint:" + waypoint);

        //check if place is valid
        if(Physics.Raycast(waypoint, -transform.up, 2f, whatIsGround))
            _isWaypointSet = true;
    }

    private void Chase()
    {
        Debug.Log("Chasing");
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        Debug.Log("Attackingfunc");
        agent.SetDestination(transform.position); //Stop moving
        transform.LookAt(player);

        if(!_attacked)
        {
            /*
                ATTACK CODE HERE!
            */
            Debug.Log("AttackCommence");
            _attacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack() {
        _attacked = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(waypoint, waypointRange);
    }
}
