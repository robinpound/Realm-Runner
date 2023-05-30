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
    public bool playerInSightRange, playerInAttackRange;

    void Awake() 
    {
        player = GameObject.FindWithTag("Player").transform;
    }
}
