using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    InputActions arrowAttackAction;
    MovementController aimingMove;
    bool isShootPressed = false;
    bool aiming = false;
    Animator animator;

    private void Awake()
    {
        arrowAttackAction = new InputActions();
        animator = GetComponent<Animator>();
        aimingMove = FindObjectOfType<MovementController>();

        //Shooting
        arrowAttackAction.PlayerActions.ArrowAttack.started += OnShooting;
        arrowAttackAction.PlayerActions.ArrowAttack.canceled += OnShooting;
        //Aiming
        arrowAttackAction.PlayerActions.ArrowAiming.started += OnAiming;
        arrowAttackAction.PlayerActions.ArrowAiming.canceled += OnAiming;
    }

    void OnShooting(InputAction.CallbackContext context) { isShootPressed = context.ReadValueAsButton(); }
    void OnAiming(InputAction.CallbackContext context) { aiming = context.ReadValueAsButton(); }

    public void BowAndArrowAttack()
    {
           if (aiming)
           {
            aiming = true;
            Debug.Log("The player is aiming  here...");
            animator.SetBool("aiming", true);
            aimingMove.RoationIfAming();
        }
        else {
            aiming = false;
            animator.SetBool("aiming", false);
        }
           if (aiming && isShootPressed)
           {
            isShootPressed = true;
            animator.SetBool("attack", true);
            Debug.Log("The player will start shooting arrows here...");
        }
        else
        {
            isShootPressed = false;
            animator.SetBool("attack", false);
        }
    }

    private void OnEnable()
    {
        arrowAttackAction.PlayerActions.Enable();
    }
    private void OnDisable()
    {
        arrowAttackAction.PlayerActions.Disable();
    }
}
