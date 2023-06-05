using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    //Movenet in the input axis
    [SerializeField]
    GameObject mainCam;
    Vector2 movementInput;
    public Vector3 movement;
    float hInput, vInput;
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
    public float runSpeed = 0.5f;
    public float walkSpeed = 0.2f;
    public bool isRunPressed;
    bool isPlayerIsRunning;
    public Vector3 runDirectionMove;

    //Jump
    public bool jumpPressed;

    //rotation varibles
    float rotationPerFrame = 15.0f;
    public float cameraRotation;
    public Vector2 cameraAimInput;
    Vector3 lookAtPosition;
    Quaternion rotation;
    Quaternion targetToLookAt;
    // public float targetToLookAt;
    Player playerController;
    Gravity playerGravity;

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
        playerController = FindObjectOfType<Player>();
        playerGravity = FindObjectOfType<Gravity>();

    }

    void OnPlayerMove(InputAction.CallbackContext context)
    {
        ////Adding the context value to the is pressed boolean
        movementInput = context.ReadValue<Vector2>();
        movement.x = movementInput.x * walkSpeed;
        movement.z = movementInput.y * walkSpeed ;
        runDirectionMove.x = movementInput.x * runSpeed ;
        runDirectionMove.z = movementInput.y * runSpeed;
        isMovementPressed = movementInput.x != 0 || movementInput.y != 0;

        //I need to get camera inputs here to move the character relative to the camera
        
    }

    void OnPlayerRun(InputAction.CallbackContext context){
        isRunPressed = context.ReadValueAsButton();
    }
    void OnPlayerLook(InputAction.CallbackContext context){
        cameraAimInput += context.ReadValue<Vector2>();

        /**TODO: I need a boolean and an if statement for when the player is carry on a weapon
        the camera follow, camera rotation an aiming will get in action**/ 
        
        // movement = transform.position * cameraAimInput.y + transform.position * cameraAimInput.x;
        // runDirectionMove = transform.forward * cameraAimInput.y + transform.right * cameraAimInput.x;
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
    public void RoationIfAming(){
        // transform.localRotation = Quaternion.Euler(0, cameraAimInput.x, 0);
    }

   
    public void PlayerRotation() {
        //PLAYER ROTATE WITH CAMERA
        // transform.localRotation = Quaternion.Euler(0, cameraAimInput.x, 0);
        lookAtPosition.x = movement.x;
        lookAtPosition.y = 0.0f;  
        lookAtPosition.z = movement.z;
        // Adding rotation to player to face at
        rotation = transform.rotation;
        
        if (isMovementPressed)
        {
            targetToLookAt = Quaternion.LookRotation(lookAtPosition);
            transform.rotation = Quaternion.Slerp(rotation, targetToLookAt, rotationPerFrame * Time.deltaTime);
            // movement = transform.TransformDirection(Vector3.forward)*walkSpeed;
        }
        
        // if (isMovementPressed)
        // {
        //     targetToLookAt = Quaternion.LookRotation(lookAtPosition).eulerAngles.y + mainCam.transform.rotation.eulerAngles.y;
        //     Quaternion rotation = Quaternion.Euler(0, targetToLookAt, 0);
        //     transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationPerFrame * Time.deltaTime);
        //     // playerGravity.movementApplied = Quaternion.Euler(0,targetToLookAt, 0) * Vector3.forward;
        //     Vector3 moveToLookAt = new Vector3( 0, 0, targetToLookAt);
        //     transform.Translate(moveToLookAt * Time.deltaTime);
            
        //     // movement = transform.TransformDirection(Vector3.forward)*walkSpeed;
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