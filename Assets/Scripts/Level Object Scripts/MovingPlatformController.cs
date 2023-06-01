using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformController : MonoBehaviour
{
    [SerializeField]
    private Transform movingPlatform, startPoint, endPoint;
    private float lerpSpeed = 1f;
    private int direction = 1;

    private void FixedUpdate()
    {
        Vector3 targetPoint = currentPlatformMoveToTarge();

        movingPlatform.position = Vector3.Lerp(movingPlatform.position, targetPoint, lerpSpeed * Time.deltaTime);

        float distanceToCurrentTarget = (targetPoint - (Vector3)movingPlatform.position).magnitude;

        if (distanceToCurrentTarget <= .1f)
            direction *= -1;
    }

    Vector3 currentPlatformMoveToTarge()
    {
        if (direction == 1)
        {
            return startPoint.position;
        } 
        else 
            return endPoint.position;

    }

    private void OnDrawGizmos()
    {
        if(movingPlatform != null && startPoint != null && endPoint != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(movingPlatform.transform.position, startPoint.transform.position);
            Gizmos.DrawLine(movingPlatform.transform.position, endPoint.transform.position);
        }
    }
}
