using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    CharacterController controller;
    float speed;
    float rotationSpeed;
    float speedJump;
    float speedYaxis;
    float playerStepOffset;
    public float jumpPeriod;
    float? lastJump;
    float? buttonPressedTime;
    Animator animator;
    Vector3 lookAtPosition;
    float targetToLookAt;
    PlayerJumps jumps;
    private float gravity=-9.81f;
    private float gravityMultiplier = 3.0f;

    //CAMERA VARIABLES
    public Transform cameraTarget;
   
    // Start is called before the first frame update
    void Start()
    {
        speedJump = 5f;
        speed = 5f;
        rotationSpeed = 6f;
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        jumps = FindObjectOfType<PlayerJumps>();
        playerStepOffset = controller.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerJump();
       
    }
    void PlayerMovement()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(hInput, 0, vInput);
        float magnitude = Mathf.Clamp01(direction.magnitude) * speed;
        direction = Quaternion.AngleAxis(cameraTarget.rotation.eulerAngles.y, Vector3.up) * direction;
        direction.Normalize();

        Vector3 velocity = direction * magnitude;
        velocity.y = speedYaxis;

        controller.Move(velocity * Time.deltaTime);
        if (direction != Vector3.zero)
        {
            animator.SetBool("walk", true);
            targetToLookAt = Quaternion.LookRotation(lookAtPosition).eulerAngles.y + cameraTarget.transform.rotation.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetToLookAt, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("walk", false);
        }
    }
    void PlayerGravity()
    {

    }

    void PlayerJump()
    {
        speedYaxis += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        if (controller.isGrounded)
        {
            lastJump = Time.time;
        }
        if (Input.GetButtonDown("Jump"))
        {
            buttonPressedTime = Time.time;
        }
        if (Time.time - lastJump <= jumpPeriod)
        {
            speedYaxis = -0.5f;
            controller.stepOffset = playerStepOffset;

            if (Time.time - buttonPressedTime <= jumpPeriod)
            {
                speedYaxis = speedJump;
                buttonPressedTime = null;
                lastJump = null;
            }
            else
            {
                controller.stepOffset = 0f;
            }
        }
    }
    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
