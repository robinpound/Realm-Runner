using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Liam.
// Edited by Mike.

public class FragmentCollectable : MonoBehaviour
{
    private GameObject player;
    private GameObject gameManager;
    [SerializeField] GameManager _gameManager;
    private const string PLAYERTAG = "Player", GAMEMANAGERTAG = "GameManager";
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(PLAYERTAG);
        gameManager = GameObject.FindGameObjectWithTag(GAMEMANAGERTAG);
        _gameManager = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        int rotateSpeed = 70; 
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == PLAYERTAG)
        {
            PlayPickUpSound();
            //FragmentCollected();
            GameObject.Destroy(gameObject);
            _gameManager.fragments++;
        }
    }

    private void FragmentCollected() => _gameManager.fragments++;

    private void PlayPickUpSound()
    {
        if (FindObjectOfType<AudioManager>() != null)
        {
            FindObjectOfType<AudioManager>().PlaySound("FragmentCollected");
        }
    }
}
