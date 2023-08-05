using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPortalManager : MonoBehaviour
{
    [SerializeField] private int currentFragments; //Change to reference the game manager
    [SerializeField] private GameObject bossPortalDoorClosed,bossPortalDoorOpen;
    [SerializeField] private GameManager gameManager;
    //[SerializeField] private bool hasPlayerReachedCastle = false; // add in later.
    private int fragmentsRequired = 3;
    private bool isDoorOpen = false; // Do once

    private void Update()
    {
        currentFragments = gameManager.GetFragments();
        if (currentFragments >= fragmentsRequired && !isDoorOpen)
        {
            OpenBossRealmPortal();
            isDoorOpen= true;
        }
    }

    private void OpenBossRealmPortal()
    {
        bossPortalDoorClosed.SetActive(false);
        bossPortalDoorOpen.SetActive(true);
    }

    public void ArrivedAtCastle()
    {
        //hasPlayerReachedCastle = true;
        // Set portal to castle checkpoint
    }
}
