using UnityEngine;
using UnityEngine.InputSystem;

public class ActionInputs : MonoBehaviour
{
    InputActions actions;
    public Vector2 inputMovement{get; private set;} = Vector2.zero;
    public Vector2 lookInput;
    public bool invertY;
    public bool isJumpPressed;
    public bool isMovementPressed;
    public bool isRunPressed;
    public bool isAimingPressed;
    public bool isShootPressed;
   private void Awake() {
        //Declaring input actions
        actions = new InputActions();

        //Actions variables
        var moveAction =  actions.PlayerActions.Movement;
        var jumpAction =  actions.PlayerActions.Jump;
        var lookAction =  actions.PlayerActions.Look;
        var runAction =  actions.PlayerActions.Run;
        var aimAction = actions.PlayerActions.ArrowAiming;
        var shootAction = actions.PlayerActions.ArrowAttack;

        //Movement
        moveAction.started += OnMove;
        moveAction.canceled += OnMove;
        moveAction.performed += OnMove;

        //Jump
        jumpAction.started += OnJump;
        jumpAction.canceled += OnJump;
        // jumpAction.performed += OnJump;

        //Look
        lookAction.started += OnLook;
        lookAction.canceled += OnLook;
        // lookAction.performed += OnLook;  

        //Run 
        runAction.started += OnRun;
        runAction.canceled += OnRun;
        runAction.performed += OnRun;

        //Aiming
        aimAction.started += OnAimAction;
        aimAction.canceled += OnAimAction;

        //Shoot
        shootAction.started += OnShooting;
        shootAction.canceled += OnShooting;
    }
    //Subscribing to the Input keys and buttons
    void OnMove(InputAction.CallbackContext ctx){
        inputMovement = ctx.ReadValue<Vector2>();
        isMovementPressed = inputMovement.sqrMagnitude > 0;  
    }

    void OnJump(InputAction.CallbackContext ctx){
        isJumpPressed = ctx.ReadValueAsButton();
    }
    void OnLook(InputAction.CallbackContext ctx){
        lookInput = ctx.ReadValue<Vector2>().normalized;
        //lookInput.y = invertY ? -lookInput.y : lookInput.y;
       
    }
    void OnRun(InputAction.CallbackContext ctx){
        isRunPressed = ctx.ReadValueAsButton();
    }

    void OnAimAction(InputAction.CallbackContext ctx) {
        isAimingPressed = ctx.ReadValueAsButton();
    }
    void OnShooting(InputAction.CallbackContext ctx) {
        isShootPressed = ctx.ReadValueAsButton();
    }

    //Eanable and Disable new Input System
    private void OnEnable() {
        actions.PlayerActions.Enable();
    }
    private void OnDisable() {
        actions.PlayerActions.Disable();
    }

}
