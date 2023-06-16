using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerScript : MonoBehaviour
{
    PlayerInputsController inputController;
    CharacterController controller;
    //Camera variables
    CameraController camara;
    [SerializeField]
    GameObject mainCam;
    Animator animator;
    //Movement variables
    bool isMovePressed;
    bool isRunPressed;
    float moveSpeed =3f;
    float speed;
    Vector3 MoveDirection;
    Vector3 targetDirection ;

    //Roataion Variables
    float smoothRotation = 10f;
    float lookAtRotation = 0;
    
    void Start()
    {
        inputController = GetComponent<PlayerInputsController>();
        controller = GetComponent<CharacterController>();
        camara = GetComponent<CameraController>();
        animator = GetComponent<Animator>();
    }
     void Update(){
        PlayerMovement();
        PlayerRotation();
        PlayerRun();
     }
     private void LateUpdate() {
        camara.CameraRotation();
     }

    void PlayerMovement(){
        
        MoveDirection = new Vector3(inputController.moveInput.x, 0, inputController.moveInput.y);
        controller.Move(targetDirection * speed * Time.deltaTime);
        //Walk animation and speed
        if (isMovePressed = MoveDirection != Vector3.zero)
        {
            isMovePressed = true;
            animator.SetBool("walk", true);
            speed = moveSpeed;
        }else{
            animator.SetBool("walk", false);
            speed =0;
        }

       
    }

    void PlayerRun(){
         //Run animation and speed
       if ( inputController.isRunning)
        {
            // isMovePressed = true;
            animator.SetBool("run", true);
            speed = 10f;
        }else{
            animator.SetBool("run", false);
            // speed =0;
        }
    }
    void PlayerRotation(){
        
        if (inputController.moveInput != Vector2.zero)
        { 
            
            lookAtRotation = Quaternion.LookRotation(MoveDirection).eulerAngles.y + mainCam.transform.rotation.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, lookAtRotation, 0);
            targetDirection = Quaternion.Euler(0, lookAtRotation,0) * Vector3.forward;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, smoothRotation * Time.deltaTime);
        }
    }








//     CharacterController controller;
//     float speed;
//     float rotationSpeed = 720f;
//     float speedJump;
//     float playerStepOffset;
//     public float jumpPeriod;
//     float? lastJump;
//     float? buttonPressedTime;
//     Animator animator;
//     Vector3 lookAtPosition;
//     float targetToLookAt;
//     float maxTimeOfJumps = .85f;
//     PlayerJumps jumps;
//     float maxHeight = 10f;
//     float jumpVelocity;
//     private float gravity=-9.81f;
//     private float gravityMultiplier = 3.0f;

//     //CAMERA VARIABLES
//     public Transform cameraTarget;
   
//     // Start is called before the first frame update
//     void Start()
//     {
//         speedJump = 15f;
//         speed = 5f;
//         rotationSpeed = 6f;
//         controller = GetComponent<CharacterController>();
//         animator = GetComponent<Animator>();
//         jumps = FindObjectOfType<PlayerJumps>();
//         playerStepOffset = controller.stepOffset;
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         PlayerMovement();
//         PlayerJump();
//         Debug.Log("Gravity " + gravity);
       
//     }
//     void PlayerMovement()
//     {
//         float hInput = Input.GetAxis("Horizontal");
//         float vInput = Input.GetAxis("Vertical");
//         Vector3 direction = new Vector3(hInput, 0, vInput);
//         float magnitude = Mathf.Clamp01(direction.magnitude);
//         direction = Quaternion.AngleAxis(cameraTarget.rotation.eulerAngles.y, Vector3.up) * direction;
//         direction.Normalize();

//         Vector3 velocity = direction * magnitude;
//         velocity.y += gravity;

//         controller.Move(velocity * Time.deltaTime);
//         if (direction != Vector3.zero)
//         {
//             animator.SetBool("walk", true);
//             Quaternion characterRotation = Quaternion.LookRotation(direction, Vector3.up);
//             transform.rotation = Quaternion.RotateTowards(transform.rotation, characterRotation, rotationSpeed * Time.deltaTime);
//             animator.SetBool("jump", false);
//             // targetToLookAt = Quaternion.LookRotation(direction).eulerAngles.y + cameraTarget.transform.rotation.eulerAngles.y;
//             // Quaternion rotation = Quaternion.Euler(0, targetToLookAt, 0);
//             // transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
//         }
//         else
//         {
//             animator.SetBool("walk", false);
//         }
//     }

//     void PlayerJump()
//     {
//         gravity += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
//         if (controller.isGrounded)
//         {
//             lastJump = Time.time;
//         }
//         if (Input.GetButtonDown("Jump"))
//         {
//             buttonPressedTime = Time.time;
//             animator.SetBool("jump", true);
//         }
//         if (Input.GetButtonUp("Jump"))
//         {
//             animator.SetBool("jump", false);
//         }
//         if (Time.time - lastJump <= jumpPeriod)
//         {
            
//             float higherPoint = maxTimeOfJumps / 2;
//             gravity = (-5.5f * maxHeight) * Mathf.Pow(higherPoint, 2);
//             jumpVelocity = (5.5f * maxHeight) * higherPoint;
//             controller.stepOffset = playerStepOffset;

//             if (Time.time - buttonPressedTime <= jumpPeriod)
//             {
//                 gravity = speedJump;
//                 buttonPressedTime = null;
//                 lastJump = null;
//             }
//             else
//             {
//                 controller.stepOffset = 0f;
//             }
//         }
//     }
//     private void OnApplicationFocus(bool focus)
//     {
//         if (focus)
//         {
//             Cursor.lockState = CursorLockMode.Locked;
//         }
//         else
//         {
//             Cursor.lockState = CursorLockMode.None;
//         }
//     }
}
