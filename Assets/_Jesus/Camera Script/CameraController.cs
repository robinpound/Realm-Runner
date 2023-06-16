using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraController : MonoBehaviour
{
    PlayerInputsController inputController;
    [SerializeField]
     Transform cameraFollow;
     float xRotation;
     float yRotation;
    
    // Start is called before the first frame update
    void Start()
    {
       inputController = GetComponent<PlayerInputsController>();
    }
    public void CameraRotation(){
        xRotation += inputController.lookInput.y;
        yRotation += inputController.lookInput.x;
        xRotation = Mathf.Clamp(xRotation, -30, 90);
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);
        
        cameraFollow.rotation = rotation;
    }
}
