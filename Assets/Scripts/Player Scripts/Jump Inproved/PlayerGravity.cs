using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    public bool isFalling;
    public Vector3 currentMovement;
    PlayerController cc;
    PlayerAnimations anim;
    ActionInputs input;
    PlayerJumps pJumps;
    public bool _isJumpAnimating = false;
    public Vector3 _appliedMovement;
    float gravityIsGrounded = -.05f;
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<ActionInputs>();
        cc = GetComponent<PlayerController>();
        anim = GetComponent<PlayerAnimations>();
        pJumps = GetComponent<PlayerJumps>();

    }
    public void HandleGravity()
    {
        isFalling = currentMovement.y <= 0.0f || !input.isJumpPressed;
        float fallMultiplier = 1.0f;
        float yMovementMultiplier = .5f;
        float normalizeFallFromHight = -20.0f;
        int jumpCountAmount = 3;
        int resetJumpCountAmount = 0;

        if (cc.IsGrounded())
        {
            if (_isJumpAnimating)
            {
                anim.animator.SetBool(anim.isJumpingHash, false);
                _isJumpAnimating = false;
                pJumps.CoroutineStart();
                if (pJumps._jumpCount == jumpCountAmount)
                {
                    pJumps._jumpCount = resetJumpCountAmount;
                    anim.animator.SetInteger(anim.jumpCountHash, pJumps._jumpCount);
                }
            }
            currentMovement.y = gravityIsGrounded;
            _appliedMovement.y = gravityIsGrounded;
        }
        else if (isFalling)
        {
            float previousYVelocity = currentMovement.y;
            currentMovement.y = currentMovement.y + (pJumps._jumpGravities[pJumps._jumpCount] * fallMultiplier * Time.deltaTime);
            _appliedMovement.y = Mathf.Max((previousYVelocity + currentMovement.y) * yMovementMultiplier, normalizeFallFromHight);
        }
        else
        {
            float previousYVelocity = currentMovement.y;
            currentMovement.y = currentMovement.y + (pJumps._jumpGravities[pJumps._jumpCount] * Time.deltaTime);
            _appliedMovement.y = (previousYVelocity + currentMovement.y) * yMovementMultiplier;
        }
    }

}
