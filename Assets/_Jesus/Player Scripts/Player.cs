using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    //Other Scripts
    PlayerJumps pJumps;
    PlayerAnimations anim;
    // declare reference variables
    PlayerCharacterController cc;
    PlayerGravity pgravity;
    ActionInputs input; // NOTE: PlayerInput class must be generated from New Input System in Inspector
    CameraMoveController camMove;
    Vector3 cameraRelativeMovement;
    // variables to store optimized setter/getter parameter IDs
    // constants
    float _rotationFactorPerFrame = 15.0f;
    float _runMultiplier = 6.0f;
    int _zero = 0;
    // gravity variables
    float _gravity = -9.8f;
    // jumping variables
    bool _isJumpPressed = false;

    // Awake is called earlier than Start in Unity's event life cycle
    void Awake()
    {
        // initially set reference variables
        pJumps = GetComponent<PlayerJumps>();
        anim = GetComponent<PlayerAnimations>();
        cc = FindObjectOfType<PlayerCharacterController>();
        // pJumps.SetupJumpVariables();
        input = GetComponent<ActionInputs>();
        pgravity = GetComponent<PlayerGravity>();
        camMove = GetComponent<CameraMoveController>();
    }

    void HandleRotation()
    {
        Vector3 positionToLookAt;
        // the change in position our character should point to
        positionToLookAt.x = cameraRelativeMovement.x;
        positionToLookAt.y = _zero;
        positionToLookAt.z = cameraRelativeMovement.z;
        // the current rotation of our character
        Quaternion currentRotation = transform.rotation;

        if (input.isMovementPressed)
        {
            // creates a new rotation based on where the player is currently pressing
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            // rotate the character to face the positionToLookAt            
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotationFactorPerFrame * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        HandleRotation();
        anim.WalkAnimation();
        pgravity.HandleGravity();
        pJumps.HandleJump();
        if (pgravity.isFalling)
        {
            pJumps.DoubleJump();
        }
    }
    void Movement()
    {
        cameraRelativeMovement = camMove.ConvertToCameraSpace( pgravity._appliedMovement );
        pgravity._appliedMovement.x = input.inputMovement.x * _runMultiplier;
        pgravity._appliedMovement.z = input.inputMovement.y * _runMultiplier;

        cc.controller.Move(cameraRelativeMovement * Time.deltaTime);
    }

    // set the initial velocity and gravity using jump heights and durations


}
