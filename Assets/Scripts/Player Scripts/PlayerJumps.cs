using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumps : MonoBehaviour
{
    CharacterController jumpController;
    PlayerInputsController inputController;
    Gravity addGrav;
    Animator animator;

    public int jumpCounts = 0;
    bool isPlayerJump = false;
    float higherPoint;
    float jumpVelocity;
    float maxTimeOfJumps = .75f; //.75
    float maxJumpHeightOfJump = 1f;


    //Different type of jumps and gravities var
    float secondJumpVelocity;
    float secondJumpGravity;
    float thirdJumpVelocity;
    float thirdJumpGravity;

    //Jumps animations
    public bool jumpHash = false;
    public int playerJumpHash;
    public int jumpCountHash;

    public Coroutine resetCurrentJump = null;

    //Adding a dictionary to apply three different type of gravity to three type of jumps
    Dictionary<int, float> jumpVelocities = new Dictionary<int, float>();
    public Dictionary<int, float> jumpGravities = new Dictionary<int, float>();

    private void Awake() {

        jumpController = GetComponent<CharacterController>();
        addGrav = FindObjectOfType<Gravity>();
        inputController = GetComponent<PlayerInputsController>();

        //Get jump count value and animation type from animator 
        playerJumpHash = Animator.StringToHash("jump");
        jumpCountHash = Animator.StringToHash("jumpCount");

        animator = GetComponent<Animator>();

        SetJumps();
    }
    void SetJumps(){
        
        higherPoint = maxTimeOfJumps / 2;
        addGrav.gravity = (-2 * maxJumpHeightOfJump) / Mathf.Pow(higherPoint, 2);
        jumpVelocity = (2 * maxJumpHeightOfJump) / higherPoint;

        secondJumpGravity = (-2 * (maxJumpHeightOfJump + 1)) / Mathf.Pow((higherPoint * 1.25f), 2);
        secondJumpVelocity = (2 * (maxJumpHeightOfJump + 1)) / (higherPoint * 1.25f);  

        thirdJumpGravity = (-2 * (maxJumpHeightOfJump + 2)) / Mathf.Pow((higherPoint * 1.75f), 2);
        thirdJumpVelocity = (2 * (maxJumpHeightOfJump + 2)) / (higherPoint * 1.5f);  
        //Velocities
        jumpVelocities.Add(1, jumpVelocity);   
        jumpVelocities.Add(2, secondJumpVelocity);
        jumpVelocities.Add(3, thirdJumpVelocity);
        //Gravities
        jumpGravities.Add(0, addGrav.gravity);
        jumpGravities.Add(1, addGrav.gravity);
        jumpGravities.Add(2, secondJumpGravity);
        jumpGravities.Add(3, thirdJumpGravity);
        
    }

    public void Jump(){
        if (!isPlayerJump && jumpController.isGrounded && inputController.jumpPressed)
        {
            if (jumpCounts < 3 && resetCurrentJump != null)
            {               
                StopCoroutine(resetCurrentJump);
            }
            //Jump Animation true here
            animator.SetInteger(jumpCountHash, jumpCounts);
            animator.SetBool(playerJumpHash, true);
            isPlayerJump = true;
            addGrav.jumpAnimation = true;
            jumpCounts += 1;
            //Adding velocity to the Y axis value of gravity
            inputController.movement.y = jumpVelocities[jumpCounts];
            addGrav.movementApplied.y = jumpVelocities[jumpCounts];
           
        }else if (!inputController.jumpPressed && isPlayerJump && jumpController.isGrounded)
        {
            isPlayerJump = false;
        }      
    }
    public void DoubleJump() {
        if (inputController.jumpPressed )
        {
            isPlayerJump = true;
            inputController.movement.y = jumpVelocity * 2f;
            inputController.runDirectionMove.y = jumpVelocity * 2f;
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
        yield return new WaitForSeconds(.5f);
        jumpCounts = 0;
    }
}
