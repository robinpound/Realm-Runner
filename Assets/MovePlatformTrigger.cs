using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformTrigger : MonoBehaviour
{
    [SerializeField]
    private MovingPlatform movingPlatform;

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Platform is triggerd by " + collision.gameObject.name);
            movingPlatform.MovePlatform();
        }
    }
}
