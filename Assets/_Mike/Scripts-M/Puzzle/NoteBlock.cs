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


    [Header("Sound Debug Settings")]
    [SerializeField]
    private GameObject sound1, sound2, sound3;

    [Header("Gizmo Settings")]
    [SerializeField]
    private Transform noteBlockCenterLocation;
    [SerializeField]
    private Vector3 gizmoSize;
    [SerializeField]
    private float gizmoOffsetX;

    private void Update()
    {
        if (playerInTrigger == true && Input.GetKeyDown(KeyCode.N)) // Change to interact action input.
        {
            PlaySoundOfBlock();
        }
    }
    /*
    // Collision not working with player.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))  // Change to arrow or sword when merged
        {
            Debug.Log(collision.gameObject.name + " has collided with " + noteId);
            PlaySoundOfBlock1();
        }
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInTrigger = false;
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
