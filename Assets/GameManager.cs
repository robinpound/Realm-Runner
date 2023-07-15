using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Edited by Mike.

public class GameManager : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private GameObject portalDoor;
    [SerializeField]
    private UIManager ui;
    public int coins;
    public int fragments;

    private bool isPortalOpened = false;

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
        if (fragments >= 2 && !isPortalOpened)
        {
            isPortalOpened = true;
            portalDoor.SetActive(true);
            ui.TellPlayerPortalIsOpen();
        } 
    }

    public int CoinCollected(int coinValue)
    {
        coins += coinValue;
        return coins;
    }
}
