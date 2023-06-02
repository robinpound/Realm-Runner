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

    //Animator animator;
    Animator animator;

    public int jumpCounts = 0;
    public bool jumpPressed = false;
    bool isPlayerJump = false;
    float higherPoint;
    float jumpVelocity;
    float jumpPreviouYvelocity;
    float maxTimeOfJumps = .75f;
    float maxJumpHeightOfJump = 1.5f;

    //Different type of jumps and gravities var
    float secondJumpVelocity;
    float secondJumpGravity;
    float thirdJumpVelocity;
    float thirdJumpGravity;

    //Jumps animations
    int jumpHash;
    public int jumpCountHash;

    public Coroutine resetCurrentJump = null;

    //Adding a dictionary to apply three different type of gravity to three type of jumps
    Dictionary<int, float> jumpVelocities = new Dictionary<int, float>();
    public Dictionary<int, float> jumpGravities = new Dictionary<int, float>();

    private void Awake() {
        jumpInput = new InputActions();
        jumpInput.PlayerActions.Jump.started += playerJumps;
        jumpInput.PlayerActions.Jump.canceled += playerJumps;
        jumpInput.PlayerActions.Jump.performed += playerJumps;

        jumpController = GetComponent<CharacterController>();
        movement = FindObjectOfType<MovementController>();
        addGrav = FindObjectOfType<Gravity>();

        //Get jump count value and animation type from animator 
        jumpHash = Animator.StringToHash("jump");
        jumpCountHash = Animator.StringToHash("jumpCount");

        animator = GetComponent<Animator>();

        SetJumps();
    }
    void playerJumps(InputAction.CallbackContext context){
        jumpPressed = context.ReadValueAsButton();
    }
    void SetJumps(){
        
        higherPoint = maxTimeOfJumps / 2;
        addGrav.gravity = (-2 * maxJumpHeightOfJump) / Mathf.Pow(higherPoint, 2);
        jumpVelocity = (2 * maxJumpHeightOfJump) / higherPoint;

        secondJumpGravity = (-2 * (maxJumpHeightOfJump + 2)) / Mathf.Pow((higherPoint * 1.25f), 2);
        secondJumpVelocity = (2 * (maxJumpHeightOfJump + 2)) / (higherPoint * 1.25f);  

        thirdJumpGravity = (-2 * (maxJumpHeightOfJump + 4)) / Mathf.Pow((higherPoint * 1.5f), 2);
        thirdJumpVelocity = (2 * (maxJumpHeightOfJump + 4)) / (higherPoint * 1.5f);  
        //Velocities
        jumpVelocities.Add(1, jumpVelocity);   
        jumpVelocities.Add(2, secondJumpVelocity);
        jumpVelocities.Add(3, thirdJumpVelocity);
        //Gravities
        jumpGravities.Add(0, addGrav.gravity);
        jumpGravities.Add(1, addGrav.gravity);
        jumpGravities.Add(2, secondJumpGravity);
        jumpGravities.Add(3, thirdJumpGravity);
        
        //if (!jumpVelocities.ContainsKey(3)) {
        //    jumpGravities.Add(3, thirdJumpGravity);
        //}
        
    }


    //Testing Jump with rigidBody
    public void RigidJump(){
        
    }

    public void Jump(){
        if (!isPlayerJump && jumpController.isGrounded && jumpPressed)
        {
            Debug.Log("Checking the jumps count..." + jumpCounts);
            if (jumpCounts < 3 && resetCurrentJump != null)
            {               
                StopCoroutine(resetCurrentJump);
            }
            //Jump Animation true here
            // animator.SetInteger(jumpCountHash, jumpCounts);
            animator.SetBool("jump", true);
            isPlayerJump = true;
            addGrav.jumpAnimation = true;
            jumpCounts += 1;
            //Adding velocity to the Y axis value of gravity
            movement.movement.y = jumpVelocities[jumpCounts] * .5f;
            movement.runDirectionMove.y = jumpVelocities[jumpCounts] * .5f;
           
        }else if (!jumpPressed && isPlayerJump && jumpController.isGrounded)
        {
            isPlayerJump = false;
        }      
    }
    public void DoubleJump() {
        if (jumpPressed && !jumpController.isGrounded)
        {
            animator.SetBool("jump", true);
            isPlayerJump = true;
            addGrav.jumpAnimation = true;
            jumpCounts += 1;
            //Adding velocity to the Y axis value of gravity
            movement.movement.y = jumpVelocities[jumpCounts] * .5f;
            movement.runDirectionMove.y = jumpVelocities[jumpCounts] * .5f;
        }
        else
        {
            isPlayerJump = false;
        }
    }
    public void CoroutineStart(){
        resetCurrentJump = StartCoroutine(ResetJumps());
    }

    public IEnumerator ResetJumps(){
        yield return new WaitForSeconds(.2f);
        jumpCounts = 0;
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
