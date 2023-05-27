using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidBody : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigidBody;
    // float gravity = 5f;
    float speed = 1f;
    float runSpeed = 2f;
     Gravity gravity;
    public float jumpAmount = 35;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;
    MovementController inputActions;
    Vector3 playerGravity;
   private void Awake() {
        rigidBody = GetComponent<Rigidbody>();
        inputActions = FindObjectOfType<MovementController>();
        gravity = FindObjectOfType<Gravity>();
   }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMovement();
        Jump();
    }
    //Movement
    void PlayerMovement(){
        playerGravity = new Vector3(0.0f, -9.81f, 0.0f);
        // gravity.PlayerGravity();
        //rigidBody.AddForce(playerGravity, ForceMode.Acceleration);
;
        inputActions.WalkOrRunAnimation();
        inputActions.PlayerRotation();
        if (inputActions.isRunPressed)
        {
            rigidBody.velocity = new Vector3(inputActions.movement.x, rigidBody.velocity.y, inputActions.movement.z) * runSpeed;
        }else {
            rigidBody.velocity = new Vector3(inputActions.movement.x, rigidBody.velocity.y, inputActions.movement.z) * speed;
        }
    }
    void Jump(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Character Jump");
            rigidBody.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
            rigidBody.AddForce(playerGravity * (gravityScale - 1) * rigidBody.mass);
        }
        
    }
}
