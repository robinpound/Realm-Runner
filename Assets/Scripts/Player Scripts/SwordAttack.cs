using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordAttack : MonoBehaviour
{
    //Player
    public GameObject player;
    public Animator animator;

    //Input action
    public InputActions action;
    Vector2 movementInput;
    
    //Attacking
    public int isAttacking;
    public bool isAttackPressed;
    public bool attack;
    private void Awake()
    {
        //Initializing the input action system
        action = new InputActions();
        //Attack
        action.PlayerActions.Attack.started += OnPlayerAttack;
        //action.PlayerActions.Attack.canceled += OnPlayerAttack;
        //action.PlayerActions.Attack.performed += OnPlayerAttack;

        //Getting animator component
        animator = GetComponent<Animator>();
        //wiil play animation based on integer value
        isAttacking = Animator.StringToHash("attack");

    }
    private void FixedUpdate()
    {
        AttackAnimation();
    }
    void OnPlayerAttack(InputAction.CallbackContext context)
    {
        StartCoroutine(Wait());
    }
    void AttackAnimation()
    {
        attack = animator.GetBool(isAttacking);

        //Walk animation
        if (isAttackPressed && !attack)
        {
            animator.SetBool(isAttacking, true);
        }
        //Stop walk animation
        else if (!isAttackPressed && attack)
        {
            animator.SetBool(isAttacking, false);
        }
    }
    IEnumerator Wait()
    {
        isAttackPressed = true;
        yield return new WaitForSeconds(2);
        isAttackPressed = false;
    }
    private void OnEnable()
    {
        action.PlayerActions.Enable();
    }
    private void OnDisable()
    {
        action.PlayerActions.Disable();
    }
}
