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

    //Run variables 
    float runSpeed = 3f;
    public bool isRunPressed;
    public Vector3 runDirectionMove;

    //rotation varibles
    float rotationPerFrame = 15.0f;
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

        //Getting animator component
        animator= GetComponent<Animator>();
    }

    void OnPlayerMove(InputAction.CallbackContext context)
    {
        //Adding the context value to the is pressed boolean
        movementInput = context.ReadValue<Vector2>();
        movement.x = movementInput.x;
        movement.z = movementInput.y;
        runDirectionMove.x = movement.x * runSpeed;
        runDirectionMove.z = movement.y * runSpeed;
        isMovementPressed = movementInput.x != 0 || movementInput.y != 0;

        Debug.Log(runDirectionMove);
    }

    void OnPlayerRun(InputAction.CallbackContext context){
        isRunPressed = context.ReadValueAsButton();
    }

    //Function to apply walk or run animation
    public void WalkOrRunAnimation() {
        playerIsWalking = animator.GetBool("walk");
        isRunPressed = animator.GetBool("run");

        //Walk animation
        if (isMovementPressed && !playerIsWalking) {
            animator.SetBool("walk", true);
        }
        //Stop walk animation
        else if(!isMovementPressed && playerIsWalking) {
            animator.SetBool("walk", false);
        }
    }

    //Player rotation to direction
    public void PlayerRotation() {

        //Position the player will looka at 
        lookAtPosition.x = movement.x;
        lookAtPosition.y = 0.0f;
        lookAtPosition.z = movement.z;
        //Adding rotation to player to face at
        rotation = transform.rotation;
        if (isMovementPressed)
        {
            targetToLookAt = Quaternion.LookRotation(lookAtPosition);
            transform.rotation = Quaternion.Slerp(rotation, targetToLookAt, rotationPerFrame * Time.deltaTime);
        }
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