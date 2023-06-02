using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaisedPlatformController : MonoBehaviour
{
    [SerializeField]
    private Transform raisingPlatform, endPoint;
    private float lerpSpeed = 1f;

    private void FixedUpdate()
    {
        // Raise platform from current position to adjustable end point.
        // To move to a method that will be called by a switch script.
        raisingPlatform.position = Vector3.Lerp(raisingPlatform.position, endPoint.position, lerpSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        if (raisingPlatform != null && endPoint != null)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(raisingPlatform.transform.position, endPoint.transform.position);
        }
    }
}
