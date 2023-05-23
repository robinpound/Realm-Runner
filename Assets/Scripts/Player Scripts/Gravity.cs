using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    bool isPlayerFalling;
    float multiplyingFall = 2.0f;
    float jumpPreviouYVelocity;
    float newJumpYVelocity;
    float nextjumpYVelocity;
    public float gravity = -9.8f;
    public float gravityIfGrounded = -.5f;
    CharacterController controller;
    MovementController movement;
    PlayerJumps jumps;

    private void Awake() {
        controller = GetComponent<CharacterController>();
        movement = FindObjectOfType<MovementController>();
        jumps = FindObjectOfType<PlayerJumps>();
    }
    public void PlayerGravity(){
    
        isPlayerFalling = movement.movement.y <= 0.0f || !jumps.jumpPressed; //Try same logic for double jump
       
        if (controller.isGrounded)
        {
            movement.movement.y = gravityIfGrounded; 
            movement.runDirectionMove.y = gravityIfGrounded;
        }else if (isPlayerFalling)
        {
            jumpPreviouYVelocity = movement.movement.y;
            newJumpYVelocity = movement.movement.y + (gravity * multiplyingFall * Time.deltaTime);
            nextjumpYVelocity = (jumpPreviouYVelocity + newJumpYVelocity) * .5f;
            movement.movement.y = nextjumpYVelocity;
            movement.runDirectionMove.y = nextjumpYVelocity;    
        
        }else{
            //Adding velovity to the Y input 
            jumpPreviouYVelocity = movement.movement.y;
            newJumpYVelocity = movement.movement.y + (gravity * Time.deltaTime);
            nextjumpYVelocity = (jumpPreviouYVelocity + newJumpYVelocity) * .5f;
            movement.movement.y = nextjumpYVelocity;
            movement.runDirectionMove.y = nextjumpYVelocity;
        }

    }
}
