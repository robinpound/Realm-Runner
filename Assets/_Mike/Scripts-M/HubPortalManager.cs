using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPortalManager : MonoBehaviour
{
    [SerializeField] private int currentFragments; //Change to reference the game manager
    [SerializeField] private GameObject bossPortalDoorClosed,bossPortalDoorOpen;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private bool hasPlayerReachedCastle = false;

    private void Start()
    {
        if (!gameManager)
        {
            Debug.LogWarning("Game manager ref not set in HubPortalManager script");
            return;
        }
    }
    private void Update()
    {

        if (currentFragments == 3)
        {
            OpenBossRealmPortal();
        }
    }

    private void OpenBossRealmPortal()
    {
        bossPortalDoorClosed.SetActive(false);
        bossPortalDoorOpen.SetActive(true);
    }

    public void ArrivedAtCastle()
    {
        hasPlayerReachedCastle = true;
        // Set portal to castle checkpoint
    }

   
}
