using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBlock1 : MonoBehaviour
{
    [SerializeField]
    private NotePuzzleManager manager;
    [SerializeField] public int noteId = 1; // used for note puzzle manager

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
