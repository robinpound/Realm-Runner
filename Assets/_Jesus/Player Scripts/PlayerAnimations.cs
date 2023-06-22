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
    // public int isWalkingHash;
    public int jumpCountHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<ActionInputs>();
       

        //Animations hash
        // isWalkingHash = Animator.StringToHash("walk");
        isRunningHash = Animator.StringToHash("run");
        isJumpingHash = Animator.StringToHash("jump");
        jumpCountHash = Animator.StringToHash("jumpCount");
    }
    public void WalkAnimation()
    {
        // bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);

        // start walking if movement pressed is true and not already walking
        if (input.isMovementPressed && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        // stop walking if isMovementPressed is false and not already walking
        else if (!input.isMovementPressed && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
        // run if movement and run pressed are true and not currently running
        // if ((input.isMovementPressed && input.isRunPressed) && !isRunning)
        // {
        //     animator.SetBool(isRunningHash, true);
        // }
        // // stop running if movement or run pressed are false and currently running
        // else if ((!input.isMovementPressed || !input.isRunPressed) && isRunning)
        // {
        //     animator.SetBool(isRunningHash, false);
        // }
    }

    // public void RunAnimation()
    // {
    //     if (input.isRunPressed && input.isMovementPressed)
    //     {
    //         animator.SetBool(isRunningHash, true);
    //     }
    //     else
    //     {
    //         animator.SetBool(isRunningHash, false);
    //     }
    // }
    public void JumpAnimation()
    {
        if (input.isJumpPressed)
        {
            animator.SetBool(isJumpingHash, true);
        }
        else
        {
            animator.SetBool(isJumpingHash, false);
        }
    }
}

