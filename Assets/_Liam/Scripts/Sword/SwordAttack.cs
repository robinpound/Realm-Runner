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

    //Attacking
    public int isAttacking;
    public bool isAttackPressed;
    public bool attacking;

    public bool swordEquipped;
    public int swordCount;

    private void Awake()
    {
        //Initializing the input action system
        action = new InputActions();

        //Getting animator component
        animator = GetComponent<Animator>();
        //wiil play animation based on integer value
        isAttacking = Animator.StringToHash("Sword");

    }
    private void Update()
    {
        if (swordEquipped && !isAttackPressed)
        {
            //Debug.Log("Worked!");
            //Attack
            action.PlayerActions.SwordAttack.started += OnPlayerAttack;
            //action.PlayerActions.SwordAttack.canceled += OnPlayerAttack;
            //action.PlayerActions.SwordAttack.performed += OnPlayerAttack;
        }
    }
    private void FixedUpdate()
    {
        AttackAnimation();
    }
    void OnPlayerAttack(InputAction.CallbackContext context)
    {
        isAttackPressed = context.ReadValueAsButton();
        Debug.Log("Worked!");
        swordCount += 1;
    }

    public void AttackAnimation()
    {


        //Start Attack animation
        if (isAttackPressed && swordCount == 1)
        {
            animator.SetInteger("swordCount", swordCount);
            //StartCoroutine(Wait());
            animator.SetBool(isAttacking, true);
            StartCoroutine(Wait1());
        }
        else if (isAttackPressed && swordCount == 2)
        {
            animator.SetInteger("swordCount", swordCount);
            //StartCoroutine(Wait());
            animator.SetBool(isAttacking, true);
            StartCoroutine(Wait1());
        }
        else if (isAttackPressed && swordCount == 3)
        {
            animator.SetInteger("swordCount", swordCount);
            //StartCoroutine(Wait());
            animator.SetBool(isAttacking, true);
            StartCoroutine(Wait1());
            StartCoroutine(SetZero());
        }
        //Stop Attack animation
        //else if (!isAttackPressed && swordCount == 4)
        //{
        //    swordCount = 0;
        //    animator.SetInteger("swordCount", swordCount);
        //    animator.SetBool(isAttacking, false);
        //}
    }
    IEnumerator Wait1()
    {
        yield return new WaitForSeconds(0.1f);
        isAttackPressed = false;
        yield return new WaitForSeconds(1f);
        //yield return new WaitForSeconds(0.5f);
        animator.SetBool(isAttacking, false);
    }
    IEnumerator SetZero()
    {
        yield return new WaitForSeconds(1f);
        swordCount = 0;
        animator.SetInteger("swordCount", swordCount);
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


