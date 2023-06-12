using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class RigidPlayer : MonoBehaviour
{
[SerializeField]
    Transform camFollow;
    float cameraPitch = 0.0f;
    bool mouseInvertY = true;


    float addGravity = 10;
    float jumpHeight = 15f;
    float maxTimeDuration = 0.3f;
    float jumpTime;
    bool isJumping = false;
    int velocity;

    Animator animator;

    ActionInputs input;
    Rigidbody rigidBody;
    Vector3 playerMoveInput = Vector3.zero;
    [SerializeField]
    float movementMultiplier = 30.0f;
    float playerRotationLerpTime = 0.35f;
    float speedRotationMultiplier = 180.0f;
    float speedPitchRotationMultiplier = 180.0f;
    Vector3 playerLookAtInput;
    Vector3 previewLookAtDir;

    //Variables to handle gravity, their will have their own script
    CapsuleCollider capsuleCollider;
    [Header("GROUND CHECK")]
    [SerializeField]bool playerIsGrounded = false;
    [SerializeField][Range(0.0f, 1.8f)] float groundCheckMultiplier = 0.5f;
    [SerializeField][Range(-0.95f, 1.01f)] float groundCheckDistance = 0.05f;
    RaycastHit raycastHit = new RaycastHit();
    public float height;
    float rotationPerFrame = 15.0f;
     public GameObject cameraTarget;

    [Header("GRAVITY")]
    [SerializeField]float currentGravityFall = -100.0f;
    [SerializeField]float minGravityFall = -100.0f;
    [SerializeField]float maxGravityFall = -1500.0f;
    [SerializeField][Range(-5.0f, -30.0f)]float currentGravityFallAmountIncrement = -30.0f;
    [SerializeField]float gravityFallTimeIncrement = 0.05f;
    [SerializeField]float playerFallingTimer = 0.0f;
    [SerializeField]float gravity = 0.0f;
    private void Awake() {
        input = FindObjectOfType<ActionInputs>();
        rigidBody = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        playerMoveInput = MovementInput();
        playerMoveInput = Movement();
        playerLookAtInput = LookDirectionInput();
        PlayerLook();
        CameraMovement();
        DistanceFromGround();
        // playerIsGrounded = GroundCheck();
        playerMoveInput.y = Gravity();
        rigidBody.AddRelativeForce(playerMoveInput, ForceMode.Force);
        rigidBody.AddForce(Physics.gravity * (addGravity - velocity) * rigidBody.mass);
    }
    void Update(){
        CharacterAnimations();
        PlayerRotation();
        Jump();
    }
    private Vector3 MovementInput(){
        return new Vector3(input.inputMovement.x, 0f, input.inputMovement.y);
    }
    private Vector3 Movement(){
        Vector3 playerMovementCal = (new Vector3(playerMoveInput.x * movementMultiplier * rigidBody.mass, playerMoveInput.y * rigidBody.mass, playerMoveInput.z * movementMultiplier * rigidBody.mass));
        return playerMovementCal;
    } 
    private Vector3 LookDirectionInput(){
        
        Vector3 previeousPlayerLookInput = playerLookAtInput;
        playerLookAtInput = new Vector3(input.lookInput.x, (mouseInvertY ? -input.lookInput.y : input.lookInput.y), 0);
        return Vector3.Lerp(previeousPlayerLookInput, playerLookAtInput * Time.deltaTime, playerRotationLerpTime);
    }
    void PlayerLook(){
        rigidBody.rotation = Quaternion.Euler(0, rigidBody.rotation.eulerAngles.y + (playerLookAtInput.x * speedRotationMultiplier),0);
    }

    void CameraMovement(){
       
        cameraPitch += playerLookAtInput.y * speedPitchRotationMultiplier;
        cameraPitch = Mathf.Clamp(cameraPitch, -39.9f, 89.9f);

        camFollow.rotation = Quaternion.Euler(cameraPitch, camFollow.rotation.eulerAngles.y, camFollow.rotation.eulerAngles.z);
    }

    void DistanceFromGround(){
        Ray ray = new Ray(transform.position , Vector3.down);
        Debug.DrawRay(rigidBody.transform.position, -Vector3.up * height, Color.red);
        if (Physics.Raycast(ray, out raycastHit))
        {
           GroundDectection();
        }
    }

    void GroundDectection()
    {
         if (raycastHit.collider.tag == "Ground")
            {
                playerIsGrounded = true;
                Debug.Log(raycastHit.distance);
            }else{
                playerIsGrounded = false;
            }
    }
    // private bool GroundCheck(){
    //     float sphereCastRadius = capsuleCollider.radius * groundCheckMultiplier;
    //     float travelDistane = capsuleCollider.bounds.extents.y - sphereCastRadius + groundCheckDistance;
    //     Debug.DrawRay(rigidBody.transform.position, -Vector3.up * raycastHit.distance * 10, Color.red, 5f);
    //     return Physics.SphereCast(rigidBody.position, sphereCastRadius, Vector3.down, out raycastHit, travelDistane);
       
        
    // }

    private float Gravity(){
        if (raycastHit.distance < 0)
        {
            gravity = 0.0f;
            currentGravityFall = minGravityFall;
        }else{
            playerFallingTimer -= Time.fixedDeltaTime;
            if (playerFallingTimer < 0.0f)
            {
                if (currentGravityFall >  maxGravityFall)
                {
                    currentGravityFall += currentGravityFallAmountIncrement;
                }
                playerFallingTimer = gravityFallTimeIncrement;
                gravity = currentGravityFall;
            }
        }
        return gravity;
    }

    public void PlayerRotation() {
        // transform.localRotation = Quaternion.Euler(0, cameraAimInput.x, 0);
        previewLookAtDir.x = playerMoveInput.x;
        previewLookAtDir.y = 0.0f;  
        previewLookAtDir.z = playerMoveInput.z;
    
        if (input.isMovementPressed)
        {
            float targetToLookAt = Quaternion.LookRotation(previewLookAtDir).eulerAngles.y + cameraTarget.transform.rotation.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetToLookAt, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationPerFrame * Time.deltaTime);
            
            Vector3 moveToLookAt = Quaternion.Euler( 0,targetToLookAt, 0) * Vector3.forward;
            // playerController.characterController.Move(moveToLookAt * 3f * Time.deltaTime);

        }
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.05f);
    }

    void CharacterAnimations(){
        if (input.isMovementPressed)
        {
            animator.SetBool("walk", true);
        }else{
            animator.SetBool("walk", false);
        }
    }
    // float addGravity = 10;
    // float jumpHeight = 15f;
    // float maxTimeDuration = 0.3f;
    // float jumpTime;
    // bool isJumping;
    // int velocity;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     input = FindObjectOfType<ActionInputs>();
    // }
    // private void FixedUpdate() {
        
    //     rigidBody.AddForce(Physics.gravity * (addGravity - velocity) * rigidBody.mass);
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    //    Jump();
    //    PlayerMovement();
    // }
    void Jump(){
         if (!isJumping && input.isJumpPressed)
        {
            jumpTime = 0;
            isJumping = true;
            // input.isJump = true;
            //Adding velocity to the rigid body 
            Debug.Log( jumpTime);
            rigidBody.velocity = new Vector3(rigidBody.velocity.x,jumpHeight,0);
            jumpTime += Time.deltaTime;

        }else if (jumpTime < maxTimeDuration && isJumping)
        {
            isJumping = false;
            // input.isJump = false;
            
        }
    }
    // void PlayerMovement(){
    //     if (input.isMovementPressed)
    //     {
    //         Debug.Log("Character move");
    //         rigidBody.velocity = new Vector3(input.inputMovement.x, 0, input.inputMovement.y) * 5f;
    //         ;
    //     }
    // }
}
