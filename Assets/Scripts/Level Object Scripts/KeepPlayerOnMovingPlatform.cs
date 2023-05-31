using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlayerOnMovingPlatform : MonoBehaviour
{
    const string PLAYER = "Player";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(PLAYER))
        {
            Debug.Log(collision.collider.name + " is ON the moving platform");
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(PLAYER))
        {
            Debug.Log(collision.collider.name + " is OFF the moving platform");
            collision.collider.transform.SetParent(null);
        }
    }

}
