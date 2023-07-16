using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField]
    private float maxRotation = 50f;
    [SerializeField]
    private float rotateSpeed = .3f;

    private void Update()
    {
        //transform.rotation = Quaternion.Euler(maxRotation * Mathf.Sin(Time.time * rotateSpeed),0f,0f
        transform.rotation = Quaternion.Euler(0f, maxRotation * (Mathf.PingPong(Time.time * rotateSpeed, 2.0f) - 1.0f), 0f);
    }
}
