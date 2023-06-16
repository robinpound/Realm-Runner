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

        // Check distance to target position vector.
        float distanceToCurrentTarget = (targetPoint - (Vector3)movingPlatform.position).magnitude;

        // Flip flop with int: (1 x -1 = -1) & (-1 x -1 = 1).
        if (distanceToCurrentTarget <= .1f)
            direction *= -1;
    }
    // Return current target vector position.
    Vector3 currentPlatformMoveToTarge()
    {
        if (direction == 1) // Set current position target in accordance with direction flip flop.
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
