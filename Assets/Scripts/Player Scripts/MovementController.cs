using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    //Movenet in the input axis
    Vector2 movementInput;
    public Vector3 movement;

    //Input action
    public InputActions action;

    //Get animator
    Animator animator;

    //Movement variables
    bool playerIsWalking;
    bool isMovementPressed = false;
    int isWalking;

    //Run variables 
    int isRunning;
    float runSpeed = 5f;
    float walkSpeed = 2f;
    public bool isRunPressed;
    bool isPlayerIsRunning;
    public Vector3 runDirectionMove;

    //Jump
    public bool jumpPressed;

    //rotation varibles
    float rotationPerFrame = 15.0f;
    public float cameraRotation;
    Vector2 cameraInput;
    Vector3 lookAtPosition;
    Quaternion rotation;
    Quaternion targetToLookAt;

    private void Awake()
    {
        //Initializing the input action system
        action = new InputActions();
        //Move
        action.PlayerActions.Movement.started += OnPlayerMove;
        action.PlayerActions.Movement.canceled += OnPlayerMove;
        action.PlayerActions.Movement.performed += OnPlayerMove;

        //Run
        action.PlayerActions.Run.started += OnPlayerRun;
        action.PlayerActions.Run.canceled += OnPlayerRun;
        action.PlayerActions.Run.performed += OnPlayerRun;
        //Look
        action.PlayerActions.Look.started += OnPlayerLook;
        action.PlayerActions.Look.canceled += OnPlayerLook;
        action.PlayerActions.Look.performed += OnPlayerLook;

        //Getting animator component
        animator= GetComponent<Animator>();
        //wiil play animation based on integer value
        isWalking = Animator.StringToHash("walk");
        isRunning = Animator.StringToHash("run");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnPlayerMove(InputAction.CallbackContext context)
    {
        //Adding the context value to the is pressed boolean
        movementInput = context.ReadValue<Vector2>();
        movement.x = movementInput.x * walkSpeed;
        movement.z = movementInput.y * walkSpeed;
        runDirectionMove.x = movementInput.x * runSpeed;
        runDirectionMove.z = movementInput.y * runSpeed;
        isMovementPressed = movementInput.x != 0 || movementInput.y != 0;
    }

    void OnPlayerRun(InputAction.CallbackContext context){
        isRunPressed = context.ReadValueAsButton();
    }
    void OnPlayerLook(InputAction.CallbackContext context){
        cameraRotation = context.ReadValue<Vector2>().x;
    }

    //Function to apply walk or run animation
    public void WalkOrRunAnimation() {
        playerIsWalking = animator.GetBool(isWalking);
        isPlayerIsRunning = animator.GetBool(isRunning);

        //Walk animation
        if (isMovementPressed && !playerIsWalking) {
            animator.SetBool(isWalking, true);
        }
        //Stop walk animation
        else if(!isMovementPressed && playerIsWalking) {
            animator.SetBool(isWalking, false);
        }
   
        if ((isMovementPressed && isRunPressed) && !isPlayerIsRunning)
        {
            animator.SetBool(isRunning, true);
        }else if ((!isMovementPressed || !isRunPressed) && isPlayerIsRunning)
        {
            animator.SetBool(isRunning, false);
        }
    }

    //Player rotation to direction
    public void PlayerRotation() {
        transform.Rotate(Vector3.up * cameraRotation * rotationPerFrame * Time.deltaTime);
        //Position the player will looka at 
        // lookAtPosition.x = movement.x;
        // lookAtPosition.y = 0.0f;
        // lookAtPosition.z = movement.z;
        // //Adding rotation to player to face at
        // rotation = transform.rotation;
        // if (isMovementPressed)
        // {
        //     targetToLookAt = Quaternion.LookRotation(lookAtPosition);
        //     transform.rotation = Quaternion.Slerp(rotation, targetToLookAt, rotationPerFrame * Time.deltaTime);
        // }
    }

    private void OnEnable()
    {
        action.PlayerActions.Enable();
    }
    private void OnDisable()
    {
        action.PlayerActions.Disable();
    }
}