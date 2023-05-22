using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumps : MonoBehaviour
{
    CharacterController jumpController;
    MovementController movement;
    //Input action
    InputActions jumpInput;
    Gravity addGrav;

    int jumpCounts = 0;
    public bool jumpPressed = false;
    bool isPlayerJump = false;
    float higherPoint;
    float jumpVelocity;
    float jumpPreviouYvelocity;
    float maxTimeOfJumps = .75f;
    float maxJumpHeightOfJump = 4f;

    //Adding a dictionary to apply three different type of gravity to three type of jumps
    Dictionary<int, float> jumpVelocities = new Dictionary<int, float>();
    Dictionary<int, float> jumpGravities = new Dictionary<int, float>();

    private void Awake() {
        jumpInput = new InputActions();
        jumpInput.PlayerActions.Jump.started += playerJumps;
        jumpInput.PlayerActions.Jump.canceled += playerJumps;
        jumpInput.PlayerActions.Jump.performed += playerJumps;

        jumpController = GetComponent<CharacterController>();
        movement = FindObjectOfType<MovementController>();
        addGrav = FindObjectOfType<Gravity>();
        SetJumps();
    }
    void playerJumps(InputAction.CallbackContext context){
        jumpPressed = context.ReadValueAsButton();
    }
    void SetJumps(){
        higherPoint = maxTimeOfJumps / 2;
        addGrav.gravity = (-2 * maxJumpHeightOfJump) / Mathf.Pow(higherPoint, 2);
        jumpVelocity = (2 * maxJumpHeightOfJump) / higherPoint;      
    }

    public void Jump(){
        if (!isPlayerJump && jumpController.isGrounded && jumpPressed)
        {
            isPlayerJump = true;
            //Adding velocity to the Y axis value of gravity
            movement.movement.y = jumpVelocity * .5f;
            movement.runDirectionMove.y = jumpVelocity * .5f;
            Debug.Log("Start jumping...");
        }else if (!jumpPressed && isPlayerJump && jumpController.isGrounded)
        {
            isPlayerJump = false;
        }  
           
        
    }
     private void OnEnable()
    {
       jumpInput.PlayerActions.Enable();
    }
    private void OnDisable()
    {
        jumpInput.PlayerActions.Disable();
    }
}
