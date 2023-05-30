using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{ 
    CharacterController characterController;
     float hInput, vInput;
    Gravity gravity;
    PlayerJumps jumps;
    //Storing input controller in a variable
    float speed = 10f;
    MovementController inputActions;
     Vector3 playerAimMoveInput;
    
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();        
        //Getting action from the input controller script
        inputActions = FindObjectOfType<MovementController>();
        jumps = FindObjectOfType<PlayerJumps>();
        gravity = FindObjectOfType<Gravity>();

        // jumps.SetJumps();
    }
    private void Update() {
        MoveIfAming();
    }

    void FixedUpdate()
    {
        //Adding the movenet action to the character controller
        if (inputActions.isRunPressed){
            characterController.Move(inputActions.runDirectionMove * inputActions.runSpeed * Time.deltaTime);
        }else{
            characterController.Move(inputActions.movement * inputActions.walkSpeed * Time.deltaTime); 
        }
       
        //Getting the walk animation from the Input controller class
        inputActions.WalkOrRunAnimation();
        //Rotation to the player
        inputActions.PlayerRotation();
        gravity.PlayerGravity();
       // inputActions.RoationIfAming();
        jumps.Jump();

        if(gravity.isPlayerFalling)
        {
            jumps.DoubleJump();
        }
    }
      public void MoveIfAming(){
        hInput=Input.GetAxisRaw("Horizontal");
        vInput=Input.GetAxisRaw("Vertical");
        playerAimMoveInput = new Vector3(hInput, 0, vInput);
        characterController.Move(playerAimMoveInput * Time.deltaTime); 
        // transform.Translate(playerAimMoveInput * walkSpeed * Time.deltaTime);
        
    }
    //Testing
    
}