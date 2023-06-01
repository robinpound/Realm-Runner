using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    private float maxRotation = 40f;
    private float rotateSpeed = 1f;

    private void Update()
    {
        //transform.rotation = Quaternion.Euler(maxRotation * Mathf.Sin(Time.time * rotateSpeed),0f,0f
        transform.rotation = Quaternion.Euler(maxRotation * (Mathf.PingPong(Time.time * rotateSpeed, 2.0f)-1.0f), 0f,0f);
    }
}
