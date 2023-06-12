using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{


    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpForce = 16f;
    float rotationFactorPerFrame = 15.0f;
    private float YaxisVelocity;
    Vector3 _cameraRelativeMovement;
    Vector3 moveDirection;
    // bool isJumpPressed;
    bool isRunIsPressed;
    bool isWalkIsPressed;
    bool isPlayerFalling;
    float gravityMultiplier = 5f;
    int jumpMaxHeight = 2;
    private CharacterController characterController;
    private Animator animator;
    ActionInputs input;
    public Vector3 currentMovement;
    bool doOneJump;
    bool doDoubleJump;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        input = GetComponent<ActionInputs>();
        
        // jumpH = maxNumOfJumps;

    }

    void Update()
    {
        currentMovement = SetInitialMovement();
        HandleJump();
        Gravity();
        // DoubleJump();
        currentMovement.y = YaxisVelocity;
        HandleRotation(_cameraRelativeMovement);
        _cameraRelativeMovement = ConvertToCameraSpace(currentMovement);
        characterController.Move(_cameraRelativeMovement * Time.deltaTime);

        
        
    }

    Vector3 SetInitialMovement()
    {
        moveDirection = new Vector3(input.inputMovement.x, 0f, input.inputMovement.y);

        isWalkIsPressed = moveDirection.magnitude != 0;
        // isJumpPressed = Input.GetButtonDown("Jump");
        PlayerAnimations();
        return moveDirection;
    }

    void PlayerAnimations()
    {
        if (input.isRunPressed)
        {
            moveDirection *= runSpeed;
            animator.SetBool("run", true);
            animator.SetBool("walk", true);
        }
        else if (isWalkIsPressed)
        {
            moveDirection *= moveSpeed;
            animator.SetBool("run", false);
            animator.SetBool("walk", true);
        }
        else
        {
            animator.SetBool("run", false);
            animator.SetBool("walk", false);
        }
    }
    void HandleJump()
    {
       
        // check if on the ground
        if ( characterController.isGrounded )
        { 
            Jump();
        }else if(isPlayerFalling && input.isJumpPressed && doDoubleJump){
            animator.SetBool("jump", true);
            YaxisVelocity = jumpForce;
            // doOneJump = false;
        }
        
    }
    void Jump()
    {
        animator.SetBool("jump", false);
        YaxisVelocity = -0.5f;

        // perform jump if jump button pressed
        if (input.isJumpPressed)
        {
            doOneJump = true;
            animator.SetBool("jump", true);
            YaxisVelocity = jumpForce;
        }
        
    }
    

    void Gravity(){
        isPlayerFalling = currentMovement.y <= 0.0f || !input.isJumpPressed;
        YaxisVelocity += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        
            //When jump over enemies
            // YaxisVelocity += Physics.gravity.y * 20f * Time.deltaTime;
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