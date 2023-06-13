using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    float jumpMaxHeight = 4.0f;
    public float gravity = -9.8f;
    public float gravityIfGrounded = -0.05f;
    float initialJumpVelocity;
    float maxJumpTime = .75f * 1.2f;
    bool isJumping = false;
    public int jumpCount = 0;
    int maxDoubleJump = 3;
    int doubleJumpLeft;

    [SerializeField] float jumpForce = 16f;
    PlayerController cc; //character controller
    PlayerAnimations anim;
    ActionInputs input;
    Player player;
    Gravity fromGravity;
    public Coroutine currentResetCoroutine = null;

    //Storing 3 different jumps heigh and gravities in dictionary
    Dictionary<int, float> jumpVelocities = new Dictionary<int, float>();
    public Dictionary<int, float> jumpGravities = new Dictionary<int, float>();

    private void Awake()
    {
        cc = GetComponent<PlayerController>();
        input = GetComponent<ActionInputs>();
        player = FindObjectOfType<Player>();
        fromGravity = GetComponent<Gravity>();
        anim = GetComponent<PlayerAnimations>();

        doubleJumpLeft = maxDoubleJump;
        JumpVar();
    }
    void JumpVar()
    {
        /**I need to add the time it will take to reach the height and devide it by two**/
        int addOrRemoveFromGravity = 2;
        int maxJumpHeightDivider = 2;
        int addingToheight = 2;
        float timeToMaxHeightMultiplier = 1.25f;
        int square = 2;
        int addGravityToThirdJump = 2;//4f
        float thirdMaxHeightMultiplier = 1.5f;

        //First jump height and gravity
        float timeToMaxHeight = jumpMaxHeight / maxJumpHeightDivider;
        gravity = (-addOrRemoveFromGravity * jumpMaxHeight) / Mathf.Pow(timeToMaxHeight, square);
        initialJumpVelocity = (addOrRemoveFromGravity + jumpMaxHeight) / timeToMaxHeight;

        //Second jump height and gravity
        float secondJumpGravity = (-addOrRemoveFromGravity * (jumpMaxHeight + addingToheight)) / Mathf.Pow((timeToMaxHeight * timeToMaxHeightMultiplier), square);
        float secondJumpVelocity = (addOrRemoveFromGravity * (jumpMaxHeight + addingToheight)) / timeToMaxHeight * timeToMaxHeightMultiplier;

        //Third jump height and gravity
        float thirdJumpGravity = (-addOrRemoveFromGravity * (jumpMaxHeight + addingToheight)) / Mathf.Pow((timeToMaxHeight * thirdMaxHeightMultiplier), square);
        float thirdJumpVelocity = (addGravityToThirdJump * (jumpMaxHeight + addingToheight)) / timeToMaxHeight * thirdMaxHeightMultiplier;

        //Jump velocities
        jumpVelocities.Add(1, initialJumpVelocity);
        jumpVelocities.Add(2, secondJumpVelocity);
        jumpVelocities.Add(3, thirdJumpVelocity);

        //Gravities
        jumpGravities.Add(0, gravity);
        jumpGravities.Add(1, gravity);
        jumpGravities.Add(2, secondJumpGravity);
        jumpGravities.Add(3, thirdJumpGravity);
    }

    public void HandleJump()
    {
        float jumpvelocityMultiplier = 1.5f;//.5f
        if (!isJumping && cc.IsGrounded() && input.isJumpPressed)
        {
            doubleJumpLeft = maxDoubleJump;
           
            if (jumpCount < 3 && currentResetCoroutine != null)
            {
                StopCoroutine(currentResetCoroutine);
            }
            isJumping = true;
            fromGravity.jumpAnimation = true;
            jumpCount += 1;
            anim.animator.SetInteger(anim.jumpCountHash, jumpCount);
            player.YaxisVelocity = jumpVelocities[jumpCount] * jumpvelocityMultiplier;
            Debug.Log(jumpCount);
        }
        else if (!input.isJumpPressed && isJumping && cc.IsGrounded())
        {
            isJumping = false;
        }
    }
    public void DoubleJump(){
        if (cc.IsGrounded() && input.isJumpPressed)
        {
            // doubleJumpLeft = maxDoubleJump;
        }
        if ( input.isJumpPressed && doubleJumpLeft > 0)
        {
            player.YaxisVelocity = jumpForce;
            doubleJumpLeft -= 1;
        }
        
    }
    public void CoroutineStart()
    {
        currentResetCoroutine = StartCoroutine(ResetJumpCount());
    }

    IEnumerator ResetJumpCount()
    {
        yield return new WaitForSeconds(.5f);
        jumpCount = 0;
    }
}
