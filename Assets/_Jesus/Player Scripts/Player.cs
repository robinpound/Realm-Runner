using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    //Other Scripts
    PlayerAnimations anim;
    // declare reference variables
    PlayerCharacterController cc;
    PlayerGravity pgravity;
    ActionInputs input; // NOTE: PlayerInput class must be generated from New Input System in Inspector
    CameraMoveController camMove;
    AimCameraControl aimCam;
    Vector3 cameraRelativeMovement;
    // variables to store optimized setter/getter parameter IDs
    // constants
    float _rotationFactorPerFrame = 15.0f;
    float _runMultiplier = 0f; //8.0f;
    float _jumpMoveMultiplier = 8.0f;
    float topSpeed = 15;
    int _zero = 0;
    // gravity variables
    float _gravity = -9.8f;
    // jumping variables
    bool _isJumpPressed = false;

    // Awake is called earlier than Start in Unity's event life cycle
    void Awake()
    {
        // initially set reference variables
        anim = GetComponent<PlayerAnimations>();
        cc = FindObjectOfType<PlayerCharacterController>();
        input = GetComponent<ActionInputs>();
        pgravity = GetComponent<PlayerGravity>();
        camMove = GetComponent<CameraMoveController>();
        aimCam = GetComponent<AimCameraControl>();

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
            _runMultiplier += 15 * Time.deltaTime;
            // creates a new rotationbased on where the player is currently pressing
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            // rotate the character to face the positionToLookAt            
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, _rotationFactorPerFrame * Time.deltaTime);
        }
        else
        {
            _runMultiplier = 0;
        }




    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        HandleRotation();
        anim.WalkAnimation();
        pgravity.HandleGravity();
        PlayerMoveAcceleration();

        if (aimCam.aimCam.activeInHierarchy)
            aimCam.RotatePlayerToAimPosition();
        if (_runMultiplier < topSpeed)
        {
            _runMultiplier = 0f;
        }
    }
    void PlayerMoveAcceleration()
    {
        if (_runMultiplier > topSpeed)
        {
            _runMultiplier = topSpeed;
        }
        else if (_runMultiplier < -topSpeed)
        {
            _runMultiplier = -topSpeed;
        }
    }
    void Movement()
    {
        cameraRelativeMovement = camMove.ConvertToCameraSpace(pgravity._appliedMovement);
        pgravity._appliedMovement.x = input.isJumpPressed ? input.inputMovement.x * _jumpMoveMultiplier : input.inputMovement.x * _runMultiplier;
        pgravity._appliedMovement.z = input.isJumpPressed ? input.inputMovement.y * _jumpMoveMultiplier : input.inputMovement.y * _runMultiplier;

        cc.controller.Move(cameraRelativeMovement * Time.deltaTime);
        Debug.Log("RUN SPEED..." + _runMultiplier);
    }


}
