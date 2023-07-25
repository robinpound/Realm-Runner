using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaisedPlatformController : MonoBehaviour
{
    [SerializeField]
    private Transform platform, endPoint;
    private float lerpSpeed = 1f;

    public void RaisePlatfrom()
    {
        // Raise platform from current position to adjustable end point.
        // To move to a method that will be called by a switch script.
        platform.position = Vector3.Lerp(platform.position, endPoint.position, lerpSpeed * Time.deltaTime);
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
