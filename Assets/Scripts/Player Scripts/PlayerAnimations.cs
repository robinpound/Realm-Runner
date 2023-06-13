using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator animator;
    ActionInputs input;
    Player player;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float runSpeed = 5f;
    int isJumpingHash;
    int isRunningHash;
    int isWalkingHash;
    public int jumpCountHash;
    bool isJumpingHashAnimator = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<ActionInputs>();
        player = GetComponent<Player>();

        //Animations hash
        isWalkingHash = Animator.StringToHash("walk");
        isRunningHash = Animator.StringToHash("run");
        isJumpingHash = Animator.StringToHash("jump");
        jumpCountHash = Animator.StringToHash("jumpCount");
    }
    public void WalkAnimation()
    {
        if (input.isRunPressed)
        {
            player.moveDirection *= runSpeed;
            animator.SetBool(isRunningHash, true);
            animator.SetBool(isWalkingHash, true);
        }
        else if (player.isWalkIsPressed)
        {
            player.moveDirection *= moveSpeed;
            animator.SetBool(isRunningHash, false);
            animator.SetBool(isWalkingHash, true);
        }
        else
        {
            animator.SetBool(isRunningHash, false);
            animator.SetBool(isWalkingHash, false);
        }
    }

    public void RunAnimation()
    {
        if (input.isRunPressed && player.isWalkIsPressed)
        {
            animator.SetBool(isRunningHash, true);
        }
        else
        {
            animator.SetBool(isRunningHash, false);
        }
    }
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

