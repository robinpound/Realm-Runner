using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBlock2 : MonoBehaviour
{
    [SerializeField]
    private NotePuzzleManager manager;
    private int noteId = 2; // used for note puzzle manager
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)  // Change to arrow or sword when merged
        {
            Debug.Log(collision.gameObject.name + " has collided with ");
            PlaySoundOfBlock2();
        }
    }
    private void PlaySoundOfBlock2()
    {
        //Play sound
        Debug.Log("Play sound of block 2");
        manager.NoteBlockSoundHasPlayed(noteId);
    }
}
