using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlayerOnMovingPlatform : MonoBehaviour
{
    const string PLAYER = "Player";

    // On trigger add set the Player as a child object to this.
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " is ON the moving platform");
        if (other.gameObject.CompareTag(PLAYER))
        {
            other.gameObject.transform.SetParent(transform);
        }

    }
    // On trigger exit, revert.
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name + " is OFF the moving platform");
        if (other.gameObject.CompareTag(PLAYER))
        {
            other.gameObject.transform.SetParent(null);
        }
    }


    /* Old Code used with collisions (Not working with Character controller)
    private void OnCollisionEnter(Collision collision)
    {
        
        Debug.Log(collision.collider.name + " is ON the moving platform");
        if (collision.collider.CompareTag(PLAYER))
        {
            
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(collision.collider.name + " is OFF the moving platform");
        if (collision.collider.CompareTag(PLAYER))
        {
            
            collision.collider.transform.SetParent(null);
        }
    }
    */


}
