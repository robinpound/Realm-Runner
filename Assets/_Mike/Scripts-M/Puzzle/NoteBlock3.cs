using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBlock3 : MonoBehaviour
{
    [SerializeField]
    private NotePuzzleManager manager;
    private int noteId = 3; // used for note puzzle manager
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if (collision != null) // Change to arrow or sword when merged
        {
            Debug.Log(collision.gameObject.name + " has collided with ");
            PlaySoundOfBlock3();
        }
    }
    private void PlaySoundOfBlock3()
    {
        //Play sound
        Debug.Log("Play sound of block 3");
        manager.NoteBlockSoundHasPlayed(noteId);
    }

   
}
