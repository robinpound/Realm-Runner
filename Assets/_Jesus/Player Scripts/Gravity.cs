using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public bool jumpAnimation = false;
    public bool isPlayerFalling;
    float multiplyingFall = 2.0f;
    float jumpPreviouYVelocity;
    float newJumpYVelocity;
    float nextjumpYVelocity;
    public float gravity = -9.8f;
    public float gravityIfGrounded = -.5f;

    Animator animator;
    CharacterController controller;
    MovementController movement;
    PlayerJumps jumps;
    public Vector3 movementApplied;

    private void Awake() {
        controller = GetComponent<CharacterController>();
        movement = FindObjectOfType<MovementController>();
        animator = GetComponent<Animator>();
        jumps = FindObjectOfType<PlayerJumps>();
    }
    public void PlayerGravity(){
    
        isPlayerFalling = movement.movement.y <= 0.0f || !jumps.jumpPressed; //Try same logic for double jump
       
        if (controller.isGrounded)
        {
            if (jumpAnimation)
            {
                jumps.CoroutineStart();
                jumpAnimation = false;
                animator.SetBool(jumps.playerJumpHash, false);
                if (jumps.jumpCounts == 3)
                {
                    jumps.jumpCounts = 0;
                    animator.SetInteger(jumps.jumpCountHash, jumps.jumpCounts);
                }
            }
            movement.movement.y = gravityIfGrounded; 
            movementApplied.y = gravityIfGrounded;
        }else if (isPlayerFalling)
        {
            jumpPreviouYVelocity = movement.movement.y;
            movement.movement.y = movement.movement.y + (jumps.jumpGravities[jumps.jumpCounts] * multiplyingFall * Time.deltaTime);
            movementApplied.y = Mathf.Max((jumpPreviouYVelocity + movement.movement.y) * .5f, -20.0f);
            // movement.movement.y = nextjumpYVelocity;
            // movement.runDirectionMove.y = nextjumpYVelocity;    
        
        }else{
            //Adding velovity to the Y input 
            jumpPreviouYVelocity = movement.movement.y;
            movement.movement.y = movement.movement.y + (jumps.jumpGravities[jumps.jumpCounts] * Time.deltaTime);
            movementApplied.y = (jumpPreviouYVelocity + movement.movement.y) * .5f;
            // movement.movement.y = nextjumpYVelocity;
            // movement.runDirectionMove.y = nextjumpYVelocity;
        }

    }
}
