using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{ 
    [HideInInspector]
    public CharacterController characterController;
    CameraController cameraController;
    float hInput, vInput;
    PlayerInputsController inputController;
    Gravity gravity;
    PlayerJumps jumps;
    PlayerAttack arrowShoot;
    //Storing input controller in a variable
    MovementController moveController;

    Vector3 playerAimMoveInput;
    //Camera rotation
    
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();        
        //Getting action from the input controller script
        moveController = FindObjectOfType<MovementController>();
        jumps = FindObjectOfType<PlayerJumps>();
        gravity = FindObjectOfType<Gravity>();
        arrowShoot = FindObjectOfType<PlayerAttack>();
        cameraController = FindObjectOfType<CameraController>();
        inputController = GetComponent<PlayerInputsController>();


        // jumps.SetJumps();
    }
    private void Update() {
        MoveIfAming();

         //Adding the movenet action to the character controller
        if (inputController.isRunPressed){
            gravity.movementApplied.x = inputController.runDirectionMove.x;
            gravity.movementApplied.z = inputController.runDirectionMove.z;
        }else{
            gravity.movementApplied.x = inputController.movement.x;
            gravity.movementApplied.z = inputController.movement.z;
            
        }
         characterController.Move(gravity.movementApplied * Time.deltaTime); 

    
        //Getting the walk animation from the Input controller class
        moveController.WalkOrRunAnimation();
        //Rotation to the player
        moveController.PlayerRotation();
        gravity.PlayerGravity();

        // arrowShoot.BowAndArrowAttack();
        cameraController.CameraRotation();
       // moveController.RoationIfAming();
        
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