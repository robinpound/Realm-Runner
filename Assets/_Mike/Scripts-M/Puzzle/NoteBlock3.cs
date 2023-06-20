using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBlock3 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            Debug.Log(collision.gameObject.name + " has collided with ");
            PlaySoundOfBlock3();
        }
    }
    private void PlaySoundOfBlock3()
    {
        //Play sound
        Debug.Log("Play sound of block 3");
    }
}
