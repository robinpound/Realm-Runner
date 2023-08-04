using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlayerOnSpider : MonoBehaviour
{
    const string PLAYER = "Player";

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name + " is ON the moving platform");
        if (other.gameObject.CompareTag(PLAYER))
        {
            Debug.Log("player on");
            other.gameObject.transform.SetParent(transform);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject.name + " is OFF the moving platform");
        if (other.gameObject.CompareTag(PLAYER))
        {
            Debug.Log("player off");
            //other.gameObject.transform.SetParent(null);
        }
    }
}
