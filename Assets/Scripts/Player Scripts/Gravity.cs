using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    ActionInputs input;
    PlayerJump fromJump;
    Player fromPlayer;
    public bool playerIsFalling;
     public bool jumpAnimation = false;
    //  public Vector3 movementApplied;
    PlayerController cc; //character controller
    PlayerAnimations anim;
   
    private void Awake()
    {
        fromJump = GetComponent<PlayerJump>();
        fromPlayer = GetComponent<Player>();
        cc = GetComponent<PlayerController>();
        input = GetComponent<ActionInputs>();
        anim = GetComponent<PlayerAnimations>();
    }

    public void PlayerGravity()
    {
        playerIsFalling = fromPlayer.YaxisVelocity <= 0.0f || !input.isJumpPressed;
        float playerFallingMultiplier = 20.0f;
        
        if (cc.IsGrounded())
        {
            if (jumpAnimation)
            {
                fromJump.CoroutineStart();
                jumpAnimation = false;
            if (fromJump.jumpCount == 3)
            {
                fromJump.jumpCount = 0;
                anim.animator.SetInteger(anim.jumpCountHash, fromJump.jumpCount);
            }
            }
            fromPlayer.YaxisVelocity = fromJump.gravityIfGrounded;
        }else if (playerIsFalling)
        {
            float previousYvelocity = fromPlayer.YaxisVelocity;
            float newYvelocity = fromPlayer.YaxisVelocity + (fromJump.jumpGravities[fromJump.jumpCount] * playerFallingMultiplier * Time.deltaTime);
            float nexVelocity = (previousYvelocity + newYvelocity) * .5f;
            fromPlayer.YaxisVelocity = newYvelocity; 
        }
        else
        {
            float previousYvelocity = fromPlayer.YaxisVelocity;
            float newYvelocity = fromPlayer.YaxisVelocity + (fromJump.jumpGravities[fromJump.jumpCount] * Time.deltaTime);
            float nexVelocity = (previousYvelocity + newYvelocity) * .5f;
            fromPlayer.YaxisVelocity = newYvelocity;
        }
    }
     
}

