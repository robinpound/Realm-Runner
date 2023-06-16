using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputsController : MonoBehaviour
{
    public Vector2 moveInput;
    public Vector2 lookInput;
    public bool isRunning;
    public bool isJump;
    InputActions actions;
    private void Awake() {
        actions = new InputActions();
        //Move input
        actions.PlayerActions.Movement.started += OnMovement;
        actions.PlayerActions.Movement.canceled += OnMovement;
        actions.PlayerActions.Movement.performed += OnMovement;

        //Look input
        actions.PlayerActions.Look.started += OnLook;
        actions.PlayerActions.Look.canceled += OnLook;
        actions.PlayerActions.Look.performed += OnLook;

        //Run input 
        actions.PlayerActions.Run.started += OnRun;
        actions.PlayerActions.Run.canceled += OnRun;
        actions.PlayerActions.Run.performed += OnRun;

        //Jump input
        actions.PlayerActions.Jump.started += OnJump;
        actions.PlayerActions.Jump.canceled += OnJump;
        actions.PlayerActions.Jump.performed += OnJump;
    }
    void OnMovement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    void OnRun(InputAction.CallbackContext context){
        isRunning = context.ReadValueAsButton();
    }
    void OnJump(InputAction.CallbackContext context){
        isJump = context.ReadValueAsButton();
    }

    private void OnEnable() {
        actions.PlayerActions.Enable();
    }
    private void OnDisable() {
        actions.PlayerActions.Disable();
    }
}
