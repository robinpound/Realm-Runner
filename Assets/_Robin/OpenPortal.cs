using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPortal : MonoBehaviour
{
    [Tooltip("Create an empty object in hierarchy. Put it here.")]
    [SerializeField] private GameObject endPoint;
    
    [Tooltip("If you want it to appear without a lerp, put 0 here")]
    [SerializeField] private float durationSeconds = 2f;

    public void openPortalDoor()
    {
        StartCoroutine(LerpOverTime());
    }

    IEnumerator LerpOverTime()
    {
        for (float t = 0f; t < durationSeconds; t += Time.deltaTime)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, endPoint.transform.position, t / durationSeconds);
            yield return 0;
        }
        gameObject.transform.position = endPoint.transform.position;
    }
        
    private void OnDrawGizmos()
    {
        if (endPoint.transform != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(gameObject.transform.position, endPoint.transform.position);
        }
    }
}
