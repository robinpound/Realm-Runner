using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractNoteArea : MonoBehaviour
{
    [Header("Debugs DONT EDIT")]
    public bool canPlayerInteractNote = false;
    private const string PLAYER = "Player";
    private UIManager ui;
    private bool hasUIDisplayed = false; // Do once

    private void Start()
    {
        ui = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        //Debug.Log(ui);
        //Debug.Log(canPlayerInteractNote);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.gameObject.CompareTag(PLAYER))
        {
            canPlayerInteractNote = true;
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
            canPlayerInteractNote = false;
            hasUIDisplayed = false;
        }
    }
}
