using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
public class miniboss_ref : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent navMA;
    [HideInInspector] public Animator animator;
    [SerializeField] public ParticleSystem ps;

    [Header("stats")]
    public float pathUpdateDelay = 0.2f;
    public float attackDelay = 1f;
    public float healDelay = 3f;
    
    public float shootingDistance = 50f;
    public float alertDistance = 100f;

    private void Awake() {
        navMA = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        //health in here
    }
}
