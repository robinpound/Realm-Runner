using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{ 
    public CharacterController characterController;
    // [SerializeField]
    // Transform cameraFollow;
    // CameraController cameraController;
    float hInput, vInput;
    Gravity gravity;
    PlayerJumps jumps;
    PlayerAttack arrowShoot;
    //Storing input controller in a variable
    float speed = 1f;
    MovementController inputActions;

    Vector3 playerAimMoveInput;
    //Camera rotation
    
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();        
        //Getting action from the input controller script
        inputActions = FindObjectOfType<MovementController>();
        jumps = FindObjectOfType<PlayerJumps>();
        gravity = FindObjectOfType<Gravity>();
        arrowShoot = FindObjectOfType<PlayerAttack>();
        // cameraController = FindObjectOfType<CameraController>();


        // jumps.SetJumps();
    }
    private void Update() {
        MoveIfAming();

         //Adding the movenet action to the character controller
        if (inputActions.isRunPressed){
            gravity.movementApplied.x = inputActions.runDirectionMove.x;
            gravity.movementApplied.z = inputActions.runDirectionMove.z;
            
            // characterController.Move(inputActions.runDirectionMove * inputActions.runSpeed * Time.deltaTime);
        }else{
            gravity.movementApplied.x = inputActions.movement.x;
            gravity.movementApplied.z = inputActions.movement.z;
            
            // characterController.Move(inputActions.movement * inputActions.walkSpeed * Time.deltaTime); 
        }
        //gravity.movementApplied = Quaternion.Euler(0, inputActions.targetToLookAt, 0) * Vector3.forward;
        // Vector3 playermove = gravity.movementApplied * inputActions.magnitude;
         characterController.Move(gravity.movementApplied * Time.deltaTime); 
       
    

    
        //Getting the walk animation from the Input controller class
        inputActions.WalkOrRunAnimation();
        //Rotation to the player
        inputActions.PlayerRotation();
        gravity.PlayerGravity();

        //arrowShoot.BowAndArrowAttack();
        // cameraController.CameraRotation();
       // inputActions.RoationIfAming();
        
        jumps.Jump();

        if (gravity.isPlayerFalling)
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
     
}