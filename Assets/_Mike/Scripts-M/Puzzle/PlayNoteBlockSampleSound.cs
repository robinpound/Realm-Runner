using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Michael

public class PlayNoteBlockSampleSound : MonoBehaviour
{
    [Header("Debugs")]
    [SerializeField]
    private bool playerInTrigger = false;
    [SerializeField]
    private Transform noteBlockCenterLocation;
    [SerializeField]
    private float gizmoOffsetX;
    [SerializeField]
    private Vector3 gizmoSize;
    private UIManager ui;
    private bool hasBlockBeenPlayed = false;

    private void Start()
    {
        ui = FindAnyObjectByType<UIManager>();

    }
    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<AudioSource>().Play(); 
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTrigger = true;
            if (!hasBlockBeenPlayed)
            {
                hasBlockBeenPlayed = true;
                ui.PressEDisplay();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTrigger = false;
            hasBlockBeenPlayed = false;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, .3f, .6f, .3f);
        Gizmos.DrawCube(noteBlockCenterLocation.position + new Vector3(gizmoOffsetX, 0, 0), gizmoSize);
    }
}
