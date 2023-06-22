using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumps : MonoBehaviour
{
    PlayerAnimations anim;
    PlayerCharacterController cc;
    Player player;
    ActionInputs input; // NOTE: PlayerInput class must be generated from New Input System in Inspector

    float _maxJumpHeight = 1.5f;
    float _maxJumpTime = .75f;
    bool _isJumping = false;
    float _initialJumpVelocity;
    float _gravity = -9.8f;
    public int _jumpCount = 0;
    int maxDoubleJump = 1;
    int doubleJumpLeft;
    PlayerGravity pGravity;

    Dictionary<int, float> _initialJumpVelocities = new Dictionary<int, float>();
    public Dictionary<int, float> _jumpGravities = new Dictionary<int, float>();
    public Coroutine _currentJumpResetRoutine = null;

    private void Awake()
    {
        cc = GetComponent<PlayerCharacterController>();
        anim = GetComponent<PlayerAnimations>();
        input = GetComponent<ActionInputs>();
        player = GetComponent<Player>();
        pGravity = GetComponent<PlayerGravity>();
        doubleJumpLeft = maxDoubleJump;
        SetupJumpVariables();
    }
    public void SetupJumpVariables()
    {
        int square = 2;
        float addSubstractFromGravity = 1.5f;
        int jumpStateHigherThanFirst = 1;
        int jumpStateHigherThanSecond = 4;
        float maxHeightSecondJumpMultiplier = 1f;
        float maxHeightThirdJumpMultiplier = 1.25f;

        float timeToApex = _maxJumpTime / 2;
        
        _gravity = (-addSubstractFromGravity * _maxJumpHeight) / Mathf.Pow(timeToApex, square);
        _initialJumpVelocity = (addSubstractFromGravity * _maxJumpHeight) / timeToApex;
        float secondJumpGravity = (-addSubstractFromGravity * (_maxJumpHeight + jumpStateHigherThanFirst)) / Mathf.Pow((timeToApex * maxHeightSecondJumpMultiplier), square);
        float secondJumpInitialVelocity = (addSubstractFromGravity * (_maxJumpHeight + jumpStateHigherThanFirst)) / (timeToApex * maxHeightSecondJumpMultiplier);
        float thirdJumpGravity = (-addSubstractFromGravity * (_maxJumpHeight + jumpStateHigherThanSecond)) / Mathf.Pow((timeToApex * maxHeightThirdJumpMultiplier), square);
        float thirdJumpInitialVelocity = (addSubstractFromGravity * (_maxJumpHeight + jumpStateHigherThanSecond)) / (timeToApex * maxHeightThirdJumpMultiplier);

        _initialJumpVelocities.Add(1, _initialJumpVelocity);
        _initialJumpVelocities.Add(2, secondJumpInitialVelocity);
        _initialJumpVelocities.Add(3, thirdJumpInitialVelocity);

        _jumpGravities.Add(0, _gravity);
        _jumpGravities.Add(1, _gravity);
        _jumpGravities.Add(2, secondJumpGravity);
        _jumpGravities.Add(3, thirdJumpGravity);
    }

    // launch character into the air with initial vertical velocity if conditions met
    public void HandleJump()
    {
        if (!_isJumping && cc.IsGrounded() && input.isJumpPressed)
        {
            doubleJumpLeft = maxDoubleJump;
            if (_jumpCount < 3 && _currentJumpResetRoutine != null)
            {
                StopCoroutine(_currentJumpResetRoutine);
            }
            anim.animator.SetBool(anim.isJumpingHash, true);
            
            _isJumping = true;
            pGravity._isJumpAnimating = true;
            _jumpCount += 1;
            anim.animator.SetInteger(anim.jumpCountHash, _jumpCount);
            pGravity.currentMovement.y = _initialJumpVelocities[_jumpCount];
            pGravity._appliedMovement.y = _initialJumpVelocities[_jumpCount];
        }
        else if (!input.isJumpPressed && _isJumping && cc.IsGrounded())
        {
            _isJumping = false;
        }
    }
    public void DoubleJump(){
        
        if (!cc.IsGrounded() && input.isJumpPressed && doubleJumpLeft > 0)
        {
            pGravity.currentMovement.y = _initialJumpVelocity * 1.0f;
            doubleJumpLeft -= 1;
        }
        
    }
    public void CoroutineStart()
    {
        _currentJumpResetRoutine = StartCoroutine(IJumpResetRoutine());
    }
    IEnumerator IJumpResetRoutine()
    {
        yield return new WaitForSeconds(.5f);
        _jumpCount = 0;
    }

}
