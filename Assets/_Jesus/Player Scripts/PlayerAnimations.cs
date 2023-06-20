using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator animator;
    ActionInputs input;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float runSpeed = 5f;
    public int isJumpingHash;
    public int isRunningHash;
    public int isWalkingHash;
    public int jumpCountHash;
    public int isAimingHash;
    public int isShootingHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<ActionInputs>();
       

        //Animations hash variables
        isWalkingHash = Animator.StringToHash("walk");
        isRunningHash = Animator.StringToHash("run");
        isJumpingHash = Animator.StringToHash("jump");
        jumpCountHash = Animator.StringToHash("jumpCount");
        isAimingHash = Animator.StringToHash("aiming");
        isShootingHash = Animator.StringToHash("shoot");
    }
    public void WalkAnimation()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
       
        // start walking if movement pressed is true and not already walking
        if (input.isMovementPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }
        // stop walking if isMovementPressed is false and not already walking
        else if (!input.isMovementPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }
        // run if movement and run pressed are true and not currently running
        if ((input.isMovementPressed && input.isRunPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        // stop running if movement or run pressed are false and currently running
        else if ((!input.isMovementPressed || !input.isRunPressed) && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    public void AimAndShootState()
    {
        bool isAiming = animator.GetBool(isAimingHash);
        bool isShooting = animator.GetBool(isShootingHash);

        if (input.isAimingPressed && !isAiming) {
            animator.SetBool(isAimingHash, true);
        }else if (!input.isAimingPressed && isAiming) {
            animator.SetBool(isAimingHash, false);
        }

        if(input.isShootPressed && !isShooting){
            animator.SetBool(isShootingHash, true);
        }else if (!input.isShootPressed && isShooting) {
            animator.SetBool(isShootingHash, false);
        }
    }
}

