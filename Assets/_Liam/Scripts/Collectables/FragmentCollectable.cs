using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Liam.
// Edited by Mike.

public class FragmentCollectable : MonoBehaviour
{
    private GameObject player;
    private GameObject gameManager;
    private const string PLAYERTAG = "Player", GAMEMANAGERTAG = "GameManager";

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(PLAYERTAG);
    }

    void Update()
    {
        int rotateSpeed = 70; 
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }

    // Edited by Mike
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == PLAYERTAG)
        {
            PlayPickUpSound();
            if (FindObjectOfType<ForestFragmentEvents>() != null) 
            {
                ForestFragmentCollected();
            } else
            {
                TutorialFragmentCollected();
            }
            
            Destroy(gameObject);
        }
    }

    private void TutorialFragmentCollected() => GameManager.Instance.fragments++;
    private void ForestFragmentCollected() => FindObjectOfType<ForestFragmentEvents>().AddToForestFragmentCount();

    private void PlayPickUpSound()
    {
        if (FindObjectOfType<AudioManager>() != null)
        {
            FindObjectOfType<AudioManager>().PlaySound("FragmentCollected");
        }
    }
}
