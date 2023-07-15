using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Edited by Mike.

public class GameManager : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private GameObject portalDoor;
    public int coins;
    public int fragments;

    private const string PLAYERTAG = "Player";

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(PLAYERTAG);
        // Reset coins and fragments on start.
        coins = 0;
        fragments = 0;
    }

    private void Update()
    {
        if (fragments >= 2)
        {
            portalDoor.SetActive(true);
        } 
    }

    public int CoinCollected(int coinValue)
    {
        coins += coinValue;
        return coins;
    }
}
