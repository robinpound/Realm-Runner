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
    PlayerAttack arrowShoot;
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
        arrowShoot = FindObjectOfType<PlayerAttack>();

        // jumps.SetJumps();
    }
    private void Update() {
        MoveIfAming();
    }

    void FixedUpdate()
    {
        //Adding the movenet action to the character controller
        if (inputActions.isRunPressed){
            inputActions.movementApplied.x = inputActions.runDirectionMove.x;
            inputActions.movementApplied.z = inputActions.runDirectionMove.z;
            // characterController.Move(inputActions.runDirectionMove * inputActions.runSpeed * Time.deltaTime);
        }else{
            inputActions.movementApplied.x = inputActions.movement.x;
            inputActions.movementApplied.z = inputActions.movement.z;
            // characterController.Move(inputActions.movement * inputActions.walkSpeed * Time.deltaTime); 
        }
        characterController.Move(inputActions.movementApplied * Time.deltaTime); 
        //Getting the walk animation from the Input controller class
        inputActions.WalkOrRunAnimation();
        //Rotation to the player
        inputActions.PlayerRotation();
        gravity.PlayerGravity();
        arrowShoot.BowAndArrowAttack();
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