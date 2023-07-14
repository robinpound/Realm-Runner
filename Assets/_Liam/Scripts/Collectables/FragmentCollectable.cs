using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Liam.
// Edited by Mike.

public class FragmentCollectable : MonoBehaviour
{
    [Header("Don't Touch")]
    public GameObject player;
    public GameObject gameManager;
    //public GameObject fragment;


    // Added by Mike
    private GameManager _gameManager;
    private const string PLAYERTAG = "Player", GAMEMANAGERTAG = "GameManager";

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag(GAMEMANAGERTAG);
        _gameManager = gameManager.GetComponent<GameManager>();

        player = GameObject.FindGameObjectWithTag(PLAYERTAG);
    }

    // Update is called once per frame
    void Update()
    {
        int rotateSpeed = 7;
        transform.Rotate(0, 10 * rotateSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("In!");
        if (other.tag == PLAYERTAG)
        {
            PickUpSound();
            FragmentCollected();
            //Debug.Log("In!");
            GameObject.Destroy(gameObject);
        }
    }

    private void FragmentCollected()
    {
        _gameManager.fragments++;
        player.GetComponent<PlayerUIKeyFragments>().fragmentsInt++;

        // Set fragment to not appear again at this location TO DO!
    }

    private void PickUpSound()
    {
        // Call pick up sound from audio manager
        FindObjectOfType<AudioManager>().PlaySound("FragmentCollected");
    }
}
