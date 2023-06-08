using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputsController : MonoBehaviour
{
    public Vector2 moveInput;
     public bool jumpPressed = false;
    public Vector2 lookInput;
    public float runSpeed = 0.5f;
    public float walkSpeed = 0.2f;
    public bool isRunning;
    public bool isRunPressed;
    public Vector2 movementInput;
     public Vector3 runDirectionMove;
    public bool isMovementPressed = false;
    public Vector3 movement;
    public Vector2 cameraAimInput;
    public bool isJump;
    InputActions actions;
    private void Awake() {
        actions = new InputActions();
        //Move input
        //Move
        actions.PlayerActions.Movement.started += OnPlayerMove;
        actions.PlayerActions.Movement.canceled += OnPlayerMove;
        actions.PlayerActions.Movement.performed += OnPlayerMove;

        //Run
        actions.PlayerActions.Run.started += OnPlayerRun;
        actions.PlayerActions.Run.canceled += OnPlayerRun;
        actions.PlayerActions.Run.performed += OnPlayerRun;
        //Look

        //Look input
        actions.PlayerActions.Look.started += OnLook;
        actions.PlayerActions.Look.canceled += OnLook;
        actions.PlayerActions.Look.performed += OnLook;

        //Jump
        actions.PlayerActions.Jump.started += playerJumps;
        actions.PlayerActions.Jump.canceled += playerJumps;
        actions.PlayerActions.Jump.performed += playerJumps;

    }
     void OnPlayerRun(InputAction.CallbackContext context){
        isRunPressed = context.ReadValueAsButton();
    }
    void OnPlayerLook(InputAction.CallbackContext context){
        cameraAimInput = context.ReadValue<Vector2>();
        // ToggleCursorMode(!_cursorLocked);
        // cameraAimInput *= 1f;

        /**TODO: I need a boolean and an if statement for when the player is carry on a weapon
        the camera follow, camera rotation an aiming will get in action**/

        // movement = transform.position * cameraAimInput.y + transform.position * cameraAimInput.x;
        // runDirectionMove = transform.forward * cameraAimInput.y + transform.right * cameraAimInput.x;
    }
    void OnPlayerMove(InputAction.CallbackContext context)
    {
        ////Adding the context value to the is pressed boolean
        movementInput = context.ReadValue<Vector2>();
        movement = transform.position;
        movement.x = movementInput.x  * walkSpeed;
        movement.z = movementInput.y * walkSpeed ;
        runDirectionMove.x = movementInput.x * runSpeed ;
        runDirectionMove.z = movementInput.y * runSpeed;
        isMovementPressed = movementInput.sqrMagnitude > 0;  
        }

    void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }
    void playerJumps(InputAction.CallbackContext context){
        jumpPressed = context.ReadValueAsButton();
        //I need to prevent adding the button adding value if pressed consecutively 
    }

    private void OnEnable() {
        actions.PlayerActions.Enable();
    }
    private void OnDisable() {
        actions.PlayerActions.Disable();
    }
}
