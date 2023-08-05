using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RaisedPlatformController : MonoBehaviour
{
    [Header("Lerp Settings")]
    [SerializeField]
    private Transform platform, endPoint;
    [SerializeField] private float durationSeconds = 2f;
    [Header("Events")]
    [SerializeField] UnityEvent showCam;

    public void RaisePlatfrom()
    {
        Debug.Log("Platforms raised");
        for (float t = 0f; t < durationSeconds; t += Time.deltaTime)
        {
            platform.transform.position = Vector3.Lerp(platform.position, endPoint.position, t / durationSeconds);
        }
        //platform.position = Vector3.Lerp(platform.position, endPoint.position, lerpSpeed * Time.deltaTime);
        showCam.Invoke();
        
    }

    private void OnDrawGizmos()
    {
        if (endPoint != null)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(platform.position, endPoint.position);
        }
    }

   
}
