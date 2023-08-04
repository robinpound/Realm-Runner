using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraTriggersTest : MonoBehaviour
{
    [SerializeField] private UnityEvent showVCam1, showVCam2, showVCam3;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            showVCam1.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            showVCam2.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            showVCam3.Invoke();
        }
    }
}
