using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code from unity forums.

public class SlidingDoor : MonoBehaviour
{
    [SerializeField]
    private Transform movingObject, endPoint, startPoint;
    private float lerpSpeed = 1f;
    private float duration = 2f;
    private Vector3 targetPoint;
    private bool isDoorOpen = false; // Do Once
    private void Start()
    {
        targetPoint = endPoint.position;
    }
    public void OpenDoor()
    {
        //movingObject.position = Vector3.Lerp(movingObject.position, targetPoint, lerpSpeed * Time.deltaTime);
        if (!isDoorOpen)
        {
            StartCoroutine(LerpOverTime(startPoint.position, endPoint.position, duration));
            isDoorOpen = true;
        }
        
    }
    private void OnDrawGizmos()
    {
        if (movingObject != null && endPoint != null)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(movingObject.transform.position, endPoint.transform.position);
        }
    }

    

    IEnumerator LerpOverTime(Vector3 startPos, Vector3 endPos, float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            movingObject.transform.position = Vector3.Lerp(startPos, endPos, t / duration);
            yield return 0;
        }
        movingObject.transform.position = endPos;
    }
}
