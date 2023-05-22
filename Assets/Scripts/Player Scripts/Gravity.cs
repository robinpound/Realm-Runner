using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    float gravity = -9.8f;
    float gravityIfGrounded = -.05f;
    CharacterController controller;
    MovementController movement;

    private void Awake() {
        controller = GetComponent<CharacterController>();
        movement = FindObjectOfType<MovementController>();
    }
    public void PlayerGravity(){
    
        if (controller.isGrounded)
        {
            // Debug.Log("If player is grounded print this...");
            movement.movement.y = gravityIfGrounded; 
            movement.runDirectionMove.y = gravityIfGrounded;
        }else{
            movement.movement.y += gravity;
            movement.runDirectionMove.y += gravity;
        }

    }
}
