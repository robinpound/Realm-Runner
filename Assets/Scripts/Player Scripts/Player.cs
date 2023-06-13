using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{ 
    Vector3 _cameraRelativeMovement;
    public Vector3 moveDirection;
    ActionInputs input;
    PlayerAnimations animations;
    
    PlayerController cc; //character controller
    PlayerJump jump;
    Gravity gravity;
    private Animator animator;
    public Vector3 currentMovement;
    float rotationFactorPerFrame = 15.0f;
    public float YaxisVelocity;
    // bool isJumpPressed;
    bool isRunIsPressed;
    public bool isWalkIsPressed;
    // bool isPlayerFalling;
    // float gravityMultiplier = 5f;
    // int jumpMaxHeight = 2;
    // bool doOneJump;
    // bool doDoubleJump;
    // int jumpCount = 0;

    void Start()
    {
        cc = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        input = GetComponent<ActionInputs>();
        jump = GetComponent<PlayerJump>();
        gravity = GetComponent<Gravity>();
        animations = GetComponent<PlayerAnimations>();
        
        // jumpH = maxNumOfJumps;

    }

    void Update()
    {
        currentMovement = SetInitialMovement();
        // HandleJump();
        // Gravity();
        // DoubleJump();
        gravity.PlayerGravity();
        jump.HandleJump();
        
        currentMovement.y = YaxisVelocity;
        HandleRotation(_cameraRelativeMovement);
        _cameraRelativeMovement = ConvertToCameraSpace(currentMovement);
        cc.controller.Move(_cameraRelativeMovement * Time.deltaTime);
        // Debug.Log(" JUMP COUNTING FOR NOW"+ jumpCount);
        if (gravity.playerIsFalling)
        {
            jump.DoubleJump();
        }
        // if(characterController.isGrounded){
        //     jumpCount = 0;
        // }
    }

    Vector3 SetInitialMovement()
    {
       moveDirection = new Vector3(input.inputMovement.x, 0f, input.inputMovement.y);
        isWalkIsPressed = moveDirection.magnitude != 0;
        // isJumpPressed = Input.GetButtonDown("Jump");
        animations.WalkAnimation();
        animations.RunAnimation();
        animations.JumpAnimation();
        return moveDirection;
    }

    void HandleRotation(Vector3 movementInput)
    {
        if (movementInput.x == 0 && movementInput.z == 0)
        {
            return;
        }
        Vector3 positionToLookAt;
        // the change in position our character should point to
        positionToLookAt.x = movementInput.x;
        positionToLookAt.y = 0;
        positionToLookAt.z = movementInput.z;
        // the current rotation of our character
        Quaternion currentRotation = transform.rotation;

        if (movementInput.magnitude != 0)
        {
            // creates a new rotation based on where the player is currently pressing
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            // rotate the character to face the positionToLookAt            
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }
    }

    Vector3 ConvertToCameraSpace(Vector3 vectorToRotate)
    {
        // store the Y value of the original vector to rotate 
        float currentYValue = vectorToRotate.y;

        // get the forward and right directional vectors of the camera
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // remove the Y values to ignore upward/downward camera angles
        cameraForward.y = 0;
        cameraRight.y = 0;

        // re-normalize both vectors so they each have a magnitude of 1
        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        // rotate the X and Z VectorToRotate values to camera space
        Vector3 cameraForwardZProduct = vectorToRotate.z * cameraForward;
        Vector3 cameraRightXProduct = vectorToRotate.x * cameraRight;

        // the sum of both products is the Vector3 in camera space and set Y value
        Vector3 vectorRotatedToCameraSpace = cameraForwardZProduct + cameraRightXProduct;
        vectorRotatedToCameraSpace.y = currentYValue;
        return vectorRotatedToCameraSpace;
    }
}