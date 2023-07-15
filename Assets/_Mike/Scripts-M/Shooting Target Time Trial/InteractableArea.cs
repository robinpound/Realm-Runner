using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableArea : MonoBehaviour
{
    [Header("Debug")]
    public bool canPlayerInteract = false;
    private const string PLAYER = "Player";
    [SerializeField]
    private UIManager ui;
    private bool hasUIDisplayed = false; // Do once
    

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.gameObject.CompareTag(PLAYER))
        {
            canPlayerInteract = true;
            if (!hasUIDisplayed)
            {
                hasUIDisplayed = true;
                ui.PressEDisplay();
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER))
        {
            canPlayerInteract = false;
            hasUIDisplayed = false;
        }
    }
}
