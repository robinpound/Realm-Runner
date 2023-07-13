using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotatingFragment : MonoBehaviour
{
    private void Update()
    {
        float rotateSpeed = 4f;
        transform.Rotate(0, 10 * rotateSpeed * Time.deltaTime , 0);
    }
}
