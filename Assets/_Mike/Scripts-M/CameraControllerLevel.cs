using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerLevel : MonoBehaviour
{
    [Header("Set cameras")]
    [SerializeField] private GameObject vcam1, vcam2, vcam3;
    [Header("Set timer in seconds")]
    [SerializeField] private float timer = 2f;

    public void ShowCam1()
    {
        if (vcam1 != null)
        {
            vcam1.SetActive(true);
            StartCoroutine(Timer(vcam1));
        }
        else Debug.LogWarning("Vcam 1 field not set in CameraControllerLevel");
    }

    public void ShowCam2()
    {
        if (vcam2 != null)
        {
            vcam2.SetActive(true);
            StartCoroutine(Timer(vcam2));
        }
        else Debug.LogWarning("Vcam 2 field not set in CameraControllerLevel");
    }

    public void ShowCam3()
    {
        if (vcam2 != null)
        {
            vcam3.SetActive(true);
            StartCoroutine(Timer(vcam3));
        }
        else Debug.LogWarning("Vcam 2 field not set in CameraControllerLevel");
    }

    IEnumerator Timer(GameObject cam)
    {
        yield return new WaitForSeconds(timer);
        cam.SetActive(false);
    }
}
