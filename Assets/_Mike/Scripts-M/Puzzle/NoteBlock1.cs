using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBlock1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null)
        {
            Debug.Log(collision.gameObject.name + " has collided with ");
            PlaySoundOfBlock1();
        }
    }
    private void PlaySoundOfBlock1()
    {
        //Play sound
        Debug.Log("Play sound of block 1");
    }
}
