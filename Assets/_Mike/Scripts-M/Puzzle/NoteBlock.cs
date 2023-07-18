using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Michael

public class NoteBlock : MonoBehaviour
{
    [Header("Note Block Settings")]
    [Tooltip("Change Id to change note this block plays, can be (1~3)")]
    [SerializeField] public int noteId; // add id in inspector

    [Header("Debugs DONT EDIT")]
    [SerializeField]
    private NotePuzzleManager manager;
    
    //private bool playerInTrigger = false;
    [SerializeField]
    private bool hasBlockBeenPlayed = false;
    private UIManager ui;
    [SerializeField]
    private InteractNoteArea interactNoteArea;
    [Header("Debugs Attach")]
    [Tooltip("Add indicator light game object here, under Visual in note block prefab.")]
    [SerializeField]
    private GameObject indicatorLight;
    //private IndicatorLightTag indicatorLightTag; // Change to tag if finding in scene
    

    [Header("Sound Debug Settings")]
    [Tooltip("Add sound to not block game object and drag and drop here")]
    [SerializeField]
    private GameObject sound1, sound2, sound3;
    /*
    [Header("Gizmo Settings")]
    [SerializeField]
    private Transform noteBlockCenterLocation;
    [SerializeField]
    private Vector3 gizmoSize;
    [SerializeField]
    private float gizmoOffsetX;
    */
    

    private void Start()
    {
        manager = GetComponentInParent<NotePuzzleManager>();
        ui = FindAnyObjectByType<UIManager>();
        interactNoteArea = GetComponentInChildren<InteractNoteArea>();
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) 
            && interactNoteArea.canPlayerInteractNote) // Change to interact action input.
        {
            PlaySoundOfBlock();
        }

        if (hasBlockBeenPlayed)
        {
            ShowIndicatorLight();
        }
    }

    
    private void PlaySoundOfBlock()
    {
        Debug.Log("Play sound of block" + noteId);
        hasBlockBeenPlayed = true;
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

    private void ShowIndicatorLight()
    {
        // Show the note blocks light to indicate player has activated it's note.
        Debug.Log("Light on note block " + noteId);
        indicatorLight.SetActive(true);
    }


}
