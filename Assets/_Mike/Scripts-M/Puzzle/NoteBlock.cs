using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBlock : MonoBehaviour
{
    [SerializeField]
    private NotePuzzleManager manager;
    [SerializeField] public int noteId; // add id in inspector

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))  // Change to arrow or sword when merged
        {
            Debug.Log(collision.gameObject.name + " has collided with " + noteId);
            PlaySoundOfBlock1();
        }
    }
    private void PlaySoundOfBlock1()
    {
        //Play sound
        Debug.Log("Play sound of block 1");
        manager.NoteBlockSoundHasPlayed(noteId);
    }
}
