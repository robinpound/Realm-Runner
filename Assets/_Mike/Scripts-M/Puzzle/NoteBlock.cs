using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Michael

public class NoteBlock : MonoBehaviour
{
    [Header("Note Block Settings")]
    
    [SerializeField] public int noteId; // add id in inspector

    [Header("Debugs")]
    [SerializeField]
    private NotePuzzleManager manager;
    [SerializeField]
    private bool playerInTrigger = false;
    private bool hasBlockBeenPlayed = false; // Do once.


    [Header("Sound Debug Settings")]
    [Tooltip("Add sound to not block game object and drag and drop here")]
    [SerializeField]
    private GameObject sound1, sound2, sound3;

    [Header("Gizmo Settings")]
    [SerializeField]
    private Transform noteBlockCenterLocation;
    [SerializeField]
    private Vector3 gizmoSize;
    [SerializeField]
    private float gizmoOffsetX;
    private UIManager ui;
    private InteractNoteArea interactNoteArea;

    private void Start()
    {
        manager = GetComponentInParent<NotePuzzleManager>();
        ui = FindAnyObjectByType<UIManager>();
        interactNoteArea = GetComponentInChildren<InteractNoteArea>();
    }
    private void Update()
    {
        if (playerInTrigger == true && Input.GetKeyDown(KeyCode.E) 
            && interactNoteArea.canPlayerInteractNote) // Change to interact action input.
        {
            PlaySoundOfBlock();
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
    private void PlaySoundOfBlock()
    {
        Debug.Log("Play sound of block 1");
        manager.NoteBlockSoundHasPlayed(noteId);
        // Play note on child game object depending on current note id.
        if (noteId == 1)
        {
            sound1.GetComponent<AudioSource>().Play();
        }
        if (noteId == 2)
        {
            sound2.GetComponent<AudioSource>().Play();
        }
        if (noteId == 3) 
        { 
            sound3.GetComponent<AudioSource>().Play();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color (0, .3f, .6f, .3f);
        Gizmos.DrawCube(noteBlockCenterLocation.position + new Vector3(gizmoOffsetX, 0, 0), gizmoSize);
    }
}
