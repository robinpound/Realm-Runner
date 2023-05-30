using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform waypointA;


    public void MovePlatform()
    {
        Debug.Log("Platform is moving");
        transform.position = Vector3.Lerp(transform.position, waypointA.position, 3f * Time.deltaTime);
    }
  
}
