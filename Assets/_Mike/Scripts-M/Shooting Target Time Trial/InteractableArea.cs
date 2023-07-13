using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableArea : MonoBehaviour
{
    [Header("Debug")]
    public bool canPlayerInteract = false;
    private const string PLAYER = "Player";

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.gameObject.CompareTag(PLAYER))
        {
            canPlayerInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER))
        {
            canPlayerInteract = false;
        }
    }
}
