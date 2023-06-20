using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem.XInput;

public class AimScript : MonoBehaviour
{
    ActionInputs input;
    //Camera to toggle
    [SerializeField] GameObject followCam;
    [SerializeField] GameObject aimCam;
    [SerializeField] Transform followPosCam;
    Cinemachine.AxisState xCamAxis, yCamAxis;
    float xRotation;
    float yRotation;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        input= GetComponent<ActionInputs>();
        
       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAimState();
        //xCamAxis.Update(Time.deltaTime);
        //yCamAxis.Update(Time.deltaTime);
        CameraRotation();



        xCamAxis.Value += input.lookInput.x * speed;
        yCamAxis.Value += input.lookInput.y * speed;
    }

    //private void LateUpdate()
    //{
    //    if(input.isAimingPressed)
    //    {
           
    //        followPosCam.localEulerAngles = new Vector3(yCamAxis.Value, followPosCam.localEulerAngles.y, followPosCam.localEulerAngles.z);
    //        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xCamAxis.Value, transform.eulerAngles.z);
           
    //    }
    //}
    public void CameraRotation()
    {
        xRotation += input.lookInput.y;
        yRotation += input.lookInput.x;
        xRotation = Mathf.Clamp(xRotation, -30, 90);
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);

        followPosCam.rotation = rotation;
    }

    public void PlayerAimState()
    {
        if (input.isAimingPressed && !aimCam.activeInHierarchy) {
            aimCam.SetActive(true);
            followCam.SetActive(false);
        }else if (!input.isAimingPressed && aimCam.activeInHierarchy) {
            aimCam.SetActive(false);
            followCam.SetActive(true);
        }
    }

}
