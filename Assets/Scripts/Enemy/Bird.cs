using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody rb;
    public Transform player; 

    private bool isplayerInCircleRange = false;
    private bool isplayerInAttackRange = false;

    [SerializeField] private float circleRange;
    [SerializeField] private float attackRange;
    [SerializeField] private float circleSpeed;
    [SerializeField] private float attackSpeed;

    [SerializeField] private LayerMask whatIsPlayer;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {
        transform.LookAt(player);
        float disctance = (player.position - transform.position).magnitude;

        isplayerInCircleRange = Physics.CheckSphere(transform.position, circleRange, whatIsPlayer);
        isplayerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!isplayerInCircleRange && !isplayerInAttackRange) Patrol(); 
        if (isplayerInCircleRange && !isplayerInAttackRange) Circle(); 
        if (isplayerInCircleRange && isplayerInAttackRange) Attack(); 
        

    }

    private void Attack()
    {
        throw new NotImplementedException();
    }

    private void Circle()
    {
        throw new NotImplementedException();
    }

    private void Patrol()
    {
        throw new NotImplementedException();
    }
}
