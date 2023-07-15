using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Liam.
// Edited by Mike.

public class CoinCollectable : MonoBehaviour
{
    private GameObject gameManager;
    //public GameObject coin;
    //public int coins;

    [Header("Added by Mike")]
    private GameManager _gameManager;
    [SerializeField]
    private int normalCoinAmount;
    private const string PLAYERTAG = "Player", GAMEMANAGERTAG = "GameManager";

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag(GAMEMANAGERTAG);
        _gameManager = gameManager.GetComponent<GameManager>();
        //coin = GameObject.FindGameObjectWithTag("Coin");
        normalCoinAmount = 1;
    }

    void Update()
    {
        int rotateSpeed = 4;
        transform.Rotate(0, 10 * rotateSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("In!");
        if(other.CompareTag(PLAYERTAG))
        {
            //Debug.Log("In!");
            //_gameManager.coins++;
            PickUpSound();
            _gameManager.CoinCollected(normalCoinAmount); // Changed to use coins collected method.
            Destroy(gameObject);
        }
    }

    private void PickUpSound()
    {
        FindObjectOfType<AudioManager>().PlaySound("CoinCollected");
    }

    
}
