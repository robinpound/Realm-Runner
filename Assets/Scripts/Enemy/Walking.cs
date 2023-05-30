using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Walking : MonoBehaviour
{
    public NavMeshAgent agent; 
    public Transform player; 
    public LayerMask whatIsGround, whatIsPlayer;

    [Header("Patroling")]    
    public Vector3 walkPoint; 
    [SerializeField] bool _isWalkPointSet;
    public float walkPointRange;

    [Header("Attacking")]    
    public float timeBetweenAttacks; 
    [SerializeField] bool _attacking;

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
        if (!isplayerInAlertRange && !isplayerInAttackRange) Chase();
    }

    private void Chase()
    {
        throw new NotImplementedException();
    }

    private void Patrol()
    {
        throw new NotImplementedException();
    }
}
