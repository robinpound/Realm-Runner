using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Edited by Mike.

public class GameManager : MonoBehaviour
{
    private GameObject player;
    public int coins;
    public int fragments;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // Reset coins and fragments on start.
        coins = 0;
        fragments = 0;
    }


    void Update()
    {

    }

    public int CoinCollected(int coinValue)
    {
        coins += coinValue;
        return coins;
    }
}
