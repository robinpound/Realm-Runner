using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraController : MonoBehaviour
{
    [SerializeField]
     Transform cameraFollow;
     float xRotation;
     float yRotation;
     MovementController lookToMove;
    // Start is called before the first frame update
    void Start()
    {
        lookToMove = FindObjectOfType<MovementController>();
    }
    public void CameraRotation(){
        xRotation = lookToMove.cameraAimInput.y;
        yRotation = lookToMove.cameraAimInput.x;
        xRotation = Mathf.Clamp(xRotation, -40, 70);
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);
        
        cameraFollow.rotation = rotation;
    }
}
