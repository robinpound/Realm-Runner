using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAreaTriggerBookKey : MonoBehaviour
{
    [SerializeField]
    private UIManager ui;
    public bool bookKeyTrigger;
    private const string PLAYER = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER))
        {
            bookKeyTrigger = true;
            ui.PressEDisplay();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER))
        {
            bookKeyTrigger = false;
            ui.StopEDisplay();
        }
    }
}
