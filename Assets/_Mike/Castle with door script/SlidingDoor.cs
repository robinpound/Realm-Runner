using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    [SerializeField]
    private Transform movingObject, endPoint;
    private float lerpSpeed = 1f;
    private Vector3 targetPoint; 
    private void Start()
    {
        targetPoint = endPoint.position;
    }
    public void OpenDoor()
    {
        movingObject.position = Vector3.Lerp(movingObject.position, targetPoint, lerpSpeed * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        if (movingObject != null && endPoint != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(movingObject.transform.position, endPoint.transform.position);
        }
    }
}
