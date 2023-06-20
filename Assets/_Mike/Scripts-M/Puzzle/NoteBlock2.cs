using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBlock2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null)
        {
            Debug.Log(collision.gameObject.name + " has collided with ");
            PlaySoundOfBlock2();
        }
    }
    private void PlaySoundOfBlock2()
    {
        //Play sound
        Debug.Log("Play sound of block 2");
    }
}
