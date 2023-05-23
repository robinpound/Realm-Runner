using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{ 
    CharacterController characterController;

    Gravity gravity;
    PlayerJumps jumps;
    //Storing input controller in a variable
    MovementController inputActions;
    
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();        
        //Getting action from the input controller script
        inputActions = FindObjectOfType<MovementController>();
        jumps = FindObjectOfType<PlayerJumps>();
        gravity = FindObjectOfType<Gravity>();

        // jumps.SetJumps();
    }

    void FixedUpdate()
    {
        //Adding the movenet action to the character controller
        if (inputActions.isRunPressed){
            characterController.Move(inputActions.runDirectionMove * Time.deltaTime);
        }else{
            characterController.Move(inputActions.movement * Time.deltaTime); 
        }
       
        //Getting the walk animation from the Input controller class
        inputActions.WalkOrRunAnimation();
        //Rotation to the player
        inputActions.PlayerRotation();
        gravity.PlayerGravity();
        jumps.Jump();

        if(gravity.isPlayerFalling)
        {
            jumps.DoubleJump();
        }
    }
    //Testing
    
}