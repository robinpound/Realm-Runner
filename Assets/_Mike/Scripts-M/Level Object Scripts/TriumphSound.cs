using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriumphSound : MonoBehaviour
{
    private const string PLAYERTAG = "Player";
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYERTAG))
        {
            PlaySound();
        }
    }

    public void PlaySound()
    {
        FindObjectOfType<AudioManager>().PlaySound("PuzzleWon");
    }
}
