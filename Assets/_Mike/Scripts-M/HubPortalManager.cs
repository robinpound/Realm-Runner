using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPortalManager : MonoBehaviour
{
    [Header("Debugs")]
    [SerializeField] private int fragmentsRequiredForest = 1;
    [SerializeField] private int fragmentsRequiredBoss = 4; // 1 tutorial level + 3 Forest level.
    [SerializeField] private int currentFragments;
    [Header("Game Object References, Put In")]
    [SerializeField] private GameObject bossPortalDoorClosed;
    [SerializeField] private GameObject bossPortalDoorOpen;
    [SerializeField] private GameObject forestPortalDoorClosed, forestPortalDoorOpen;
    [Tooltip("Attach light trail off and on game objects to corrosponding fields")]
    [SerializeField] private GameObject lightToBossPortalOff,lightToBossPortalOn;
    [SerializeField] private GameObject lightToForestPortalOff, lightToForestPortalOn;
    //[SerializeField] private bool hasPlayerReachedCastle = false; // add in later.
    
    private bool isBossDoorOpen = false, isForestDoorOpen; // Do once

    private void Update()
    {
        currentFragments = GameManager.Instance.GetFragments();
        if (currentFragments >= fragmentsRequiredForest && !isForestDoorOpen)
        {
            OpenForestRealmPortal();
            isForestDoorOpen = true;
        }
        if (currentFragments >= fragmentsRequiredBoss && !isBossDoorOpen)
        {
            OpenBossRealmPortal();
            isBossDoorOpen= true;
        }
        
    }

    private void OpenForestRealmPortal()
    {
        forestPortalDoorClosed.SetActive(false);
        lightToForestPortalOff.SetActive(false);

        forestPortalDoorOpen.SetActive(true);
        lightToForestPortalOn.SetActive(true);
    }

    private void OpenBossRealmPortal()
    {
        bossPortalDoorClosed.SetActive(false);
        lightToBossPortalOff.SetActive(false);

        bossPortalDoorOpen.SetActive(true);
        lightToBossPortalOn.SetActive(true);
    }

    public void ArrivedAtCastle()
    {
        //hasPlayerReachedCastle = true;
        // Set portal to castle checkpoint
    }
}
