using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

public class AimCameraControl : MonoBehaviour
{
    // public GameObject camFollow;
    [Tooltip("Aim camera to be added from Player / CamwerasNew / AimCam")]
    public GameObject aimCam;
    //public GameObject arrowPowerUp;
    public GameObject reticle;
    [SerializeField] Transform aimTarget;
    ActionInputs input;
    [SerializeField] Rig rig;
    float rigWeight;
    [Header("Aim camera settings")]
    [Tooltip("Cinemachine X and Y axis")]
    public Cinemachine.AxisState xAxis, yAxis;
    [Tooltip("Object to be followed by aim cam")]
    [SerializeField] Transform cameraTransform;
    [SerializeField] Transform aimPos;
    [SerializeField] LayerMask aimLayerMask;
    [SerializeField] float aimSmoothSpeed = 20;
    [SerializeField] Transform aimingPos;
    Animator animator;

    public bool mouse;
    public bool shoot;
    void Start()
    {
        input = GetComponent<ActionInputs>();
        animator = GetComponent<Animator>();
        cameraTransform = Camera.main.transform;
        rig.weight = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        AnimationShootObject();
        CameraAimToggle();
        // CameraRotation();
        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);
        
    }

    public void CameraAimToggle()
    {
        //These inputs needs to be replaced for the new iput system mouse buttons
        if (mouse)
        {
            RotatePlayerToAimPosition();
            //aimCam.SetActive(true);
            animator.SetBool("aiming", true);
            reticle.SetActive(true);
            rig.weight = 1f;
            
        }
        if (!mouse )
        {
            //aimCam.SetActive(false);
            animator.SetBool("aiming", false);
            reticle.SetActive(false);
            rig.weight = 0f;
        }
    }
public void RotatePlayerToAimPosition(){
    float rotationSpeed = 10f;
    float aimDistance = 10;
    Quaternion rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
    transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

    //Aim target position 
    aimTarget.position = cameraTransform.position + cameraTransform.forward * aimDistance;
}

    void AnimationShootObject(){
        if (shoot)
        {
            animator.SetBool("attack", true);
        } 
        if (!shoot)
        {
            animator.SetBool("attack", false);
        } 
    }
   
}
