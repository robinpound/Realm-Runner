using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 cameraOffSet;
    InputActions cameraAction;
    Vector2 mouseCameraOrbit;
    public bool cameraOrbitRotation = true;
    Vector3 newPosition;
    [Range(0.01f, 1.0f)]
    public float smoothCam;
    public Vector3 offSet;
    Quaternion camAngle;
    Vector2 cameraOrbit;
    float rotationSpeed = 10f;
    public bool lookAtPlayer = true;

    private void Awake() {
        smoothCam = 0.103f;
        cameraAction = new InputActions();
        cameraOffSet = transform.position - target.transform.position;
        cameraAction.PlayerActions.Look.started += OnCameraOrbit;
        cameraAction.PlayerActions.Look.canceled += OnCameraOrbit;
        cameraAction.PlayerActions.Look.performed += OnCameraOrbit;
    }
    void LateUpdate() {
        newPosition = target.transform.position + cameraOffSet;
        transform.position = Vector3.Slerp(transform.position, newPosition, smoothCam);
         if (cameraOrbitRotation)
        {
            //Needs to get the mouse value to apply it to the camera axis
            //Quaternion to rotate the camera
            camAngle = Quaternion.AngleAxis(Input.GetAxisRaw("Mouse X") * rotationSpeed, Vector3.up);
            cameraOffSet = camAngle * cameraOffSet;
            //NOT SURE IF WORKING BUT LETS TRY IT
        }
        if (lookAtPlayer || cameraOrbitRotation)
        {
            transform.LookAt(target);
        }
        // Vector3.Slerp(transform.position, newPosition, smoothCam);
    }
    void OnCameraOrbit(InputAction.CallbackContext ctx){
        mouseCameraOrbit = ctx.ReadValue<Vector2>();
    }
    // BETTER CAMERA MOVE CONTROLLER #2

    // float smoothTimer = 0.5f;
    // float initialOffset = 0.0f;
    // private Vector3 velocityLerp = Vector3.zero;
    // Vector3 relativeVelocity;
    // Vector3 cameraPosition;
    // Vector3 positionRelativeToCamera;
    // Vector3 relativeToWorld;
    // Vector3 yOffSetPosition;
    // public CharacterController controller;

    // private void Awake() {
    //     //Setting the camera position and rotation
    //     transform.SetPositionAndRotation(new Vector3(controller.transform.position.x, 
    //     controller.transform.position.y + 2, controller.transform.position.z), transform.rotation);
    // }
    // void Update() {
    //     CameraSetUp();
    // }

    // void CameraSetUp(){
    //     //Camera velocity
    //     relativeVelocity = Camera.main.transform.InverseTransformVector(controller.velocity);
    //     initialOffset += relativeVelocity.normalized.x;

    //     //Camera position
    //     cameraPosition = Camera.main.transform.InverseTransformVector(controller.transform.position);

    //     positionRelativeToCamera = new Vector3(cameraPosition.x + relativeVelocity.x, cameraPosition.y, cameraPosition.z);
    //     relativeToWorld = Camera.main.transform.TransformVector(positionRelativeToCamera);
    //     yOffSetPosition = new Vector3(relativeToWorld.x, relativeToWorld.y + 2, relativeToWorld.z);

    //     if (controller.isGrounded && relativeVelocity.magnitude != 0)
    //     {
    //         transform.SetLocalPositionAndRotation(Vector3.SmoothDamp(transform.position, yOffSetPosition, ref velocityLerp, smoothTimer), Camera.main.transform.rotation);
    //     }


    //     Debug.Log(initialOffset);
    // }

    //BASIC CAMERA FOLLOW MOVE #1 

    // // This header will show the references in the editor

    // InputActions cameraAction;

    // [Header("Camera follow references")]
    // //Will apply transform to player
    // [SerializeField] private Transform _playerTransform;
    // public float smoothSpeed = 1.025f;
    // public Vector3 offSet;
    // Vector2 mouseCameraOrbit;

    // private Player _player;

    // // Camera rotation variables
    // public bool cameraOrbitRotation = true;
    // public float rotationSpeed;
    // Quaternion camAngle;
    // Vector2 cameraOrbit;

    // private void Awake()
    // {
    //     offSet.z=-0.07f;
    //     offSet.y = 0.7f;
    //     rotationSpeed = 10f;

    //     cameraAction = new InputActions();
    //     //Getting the player to our transform component
    //     _player = _playerTransform.gameObject.GetComponent<Player>();
    //     transform.position = _playerTransform.position;
    //     StopCoroutine(PlayerMove());

    //     cameraAction.PlayerActions.Look.started += OnCameraOrbit;
    //     cameraAction.PlayerActions.Look.canceled += OnCameraOrbit;
    //     cameraAction.PlayerActions.Look.performed += OnCameraOrbit;
    // }
    // void Update()
    // {
    //     StartCoroutine(PlayerMove());
    //      if (cameraOrbitRotation)
    //     {
    //         //Needs to get the mouse value to apply it to the camera axis
    //         //Quaternion to rotate the camera
    //         camAngle = Quaternion.AngleAxis(mouseCameraOrbit.x * rotationSpeed, Vector3.up);
    //         offSet = camAngle * offSet;
    //         //NOT SURE IF WORKING BUT LETS TRY IT
    //     }
       
    // }
    // void OnCameraOrbit(InputAction.CallbackContext ctx){
    //     mouseCameraOrbit = ctx.ReadValue<Vector2>();
    // }
  
    // private IEnumerator PlayerMove()
    // {
        
    //     if (_player != null || cameraOrbitRotation)
    //     {
    //         Vector3 targetPosition = _player.transform.position + offSet;
    //         Vector3 movedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);
    //         transform.position = movedPosition;
    //         yield return new WaitForSeconds(.2f);

    //         Debug.Log("Value on X axis" + mouseCameraOrbit.x);
    //         Debug.Log("Value on Y axis" + mouseCameraOrbit.y);
    //     }
    // }
    //Enamble input actions
    private void OnEnable() {
        cameraAction.PlayerActions.Enable();
    }
    private void OnDisable() {
        cameraAction.PlayerActions.Disable();
    }
}
