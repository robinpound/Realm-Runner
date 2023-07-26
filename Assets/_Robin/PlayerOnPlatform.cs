using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnPlatform : MonoBehaviour
{
   

    // On trigger add set the Player as a child object to this.
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " is ON the moving platform");
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(transform);
        }

    }
    // On trigger exit, revert.
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name + " is OFF the moving platform");
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
