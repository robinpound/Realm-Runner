using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    //OTHER SCRIPTS
    Player playerController;
    Gravity playerGravity;
    PlayerInputsController actionInputs;

    //Movenet in the input axis
    float hInput, vInput;
    //Input action
    
    //Get animator
    Animator animator;

    //Movement variables
    bool playerIsWalking;
    int isWalking;

    //Run variables 
    int isRunning;
    public float magnitude;
    bool isPlayerIsRunning;
    // public Vector3 runDirectionMove;
    public Vector3 moveToLookAt;
    private bool _cursorLocked;

    //Jump
    public bool jumpPressed;

    //rotation varibles
    float rotationPerFrame = 15.0f;
    public float cameraRotation;
    public Vector2 cameraAimInput;
    Vector3 lookAtPosition;
    Quaternion rotation;
    public float targetToLookAt;
    

    //Camera
    public GameObject cameraTarget;

    private void Awake()
    {
        //Getting animator component
        animator= GetComponent<Animator>();
        //wiil play animation based on integer value
        isWalking = Animator.StringToHash("walk");
        isRunning = Animator.StringToHash("run");
        playerController = FindObjectOfType<Player>();
        playerGravity = FindObjectOfType<Gravity>();

        actionInputs = GetComponent<PlayerInputsController>();

        _cursorLocked = Cursor.lockState == CursorLockMode.Locked;

    }

    private void ToggleCursorMode(bool newValue)
    {
        _cursorLocked = newValue;

        Cursor.visible = !_cursorLocked; //hiding/revealing
        Cursor.lockState = _cursorLocked ? CursorLockMode.Locked : CursorLockMode.None; //locking/unlocking
    }

    //Function to apply walk or run animation
    public void WalkOrRunAnimation() {
        playerIsWalking = animator.GetBool(isWalking);
        isPlayerIsRunning = animator.GetBool(isRunning);

        //Walk animation
        if (actionInputs.isMovementPressed && !playerIsWalking) {
            animator.SetBool(isWalking, true);
        }
        //Stop walk animation
        else if(!actionInputs.isMovementPressed && playerIsWalking) {
            animator.SetBool(isWalking, false);
        }
   
        if ((actionInputs.isMovementPressed && actionInputs.isRunPressed) && !isPlayerIsRunning)
        {
            animator.SetBool(isRunning, true);
        }else if ((!actionInputs.isMovementPressed || !actionInputs.isRunPressed) && isPlayerIsRunning)
        {
            animator.SetBool(isRunning, false);
        }
    }

    //Player rotation to direction
    public void RoationIfAming(){
        // transform.localRotation = Quaternion.Euler(0, cameraAimInput.x, 0);
    }

   
    public void PlayerRotation() {
        // transform.localRotation = Quaternion.Euler(0, cameraAimInput.x, 0);
        lookAtPosition.x = actionInputs.movement.x;
        lookAtPosition.y = 0.0f;  
        lookAtPosition.z = actionInputs.movement.z;
    
        if (actionInputs.isMovementPressed)
        {
            targetToLookAt = Quaternion.LookRotation(lookAtPosition).eulerAngles.y + cameraTarget.transform.rotation.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetToLookAt, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationPerFrame * Time.deltaTime);
            
            moveToLookAt = Quaternion.Euler( 0,targetToLookAt, 0) * Vector3.forward;
            playerController.characterController.Move(moveToLookAt * 3f * Time.deltaTime);

        }
        if (actionInputs.isRunPressed)
        {
            playerController.characterController.Move(moveToLookAt * 7f * Time.deltaTime);
        }
    }
}