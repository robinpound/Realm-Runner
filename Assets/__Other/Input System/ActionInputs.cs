using UnityEngine;
using UnityEngine.InputSystem;

public class ActionInputs : MonoBehaviour
{
    InputActions actions;
    public Vector2 inputMovement{get; private set;} = Vector2.zero;
    public Vector2 lookInput {get; private set;} = Vector2.zero;
    public bool isJumpPressed;
    public bool isMovementPressed;
    public bool isRunPressed;
    // Start is called before the first frame update
   private void Awake() {
        
        actions = new InputActions();
        var moveAction =  actions.PlayerActions.Movement;
        var jumpAction =  actions.PlayerActions.Jump;
        var lookAction =  actions.PlayerActions.Look;
        var runAction =  actions.PlayerActions.Run;

        //Movement
        moveAction.started += OnMove;
        moveAction.canceled += OnMove;
        moveAction.performed += OnMove;

        //Jump
        jumpAction.started += OnJump;
        jumpAction.canceled += OnJump;
       
        //Look
        lookAction.started += OnLook;
        lookAction.canceled += OnLook;

        //Run 
        // runAction.started += OnRun;
        // runAction.canceled += OnRun;
        // runAction.performed += OnRun;  
    }

    void OnMove(InputAction.CallbackContext ctx){
        inputMovement = ctx.ReadValue<Vector2>();
        isMovementPressed = inputMovement.sqrMagnitude > 0;  
    }

    void OnJump(InputAction.CallbackContext ctx){
        isJumpPressed = ctx.ReadValueAsButton();
    }
    void OnLook(InputAction.CallbackContext ctx){
        lookInput = ctx.ReadValue<Vector2>();
    }
    // void OnRun(InputAction.CallbackContext ctx){
    //     isRunPressed = ctx.ReadValueAsButton();
    // }

    private void OnEnable() {
        actions.PlayerActions.Enable();
    }
    private void OnDisable() {
        actions.PlayerActions.Disable();
    }

}
