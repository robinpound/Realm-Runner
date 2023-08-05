using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPortalManager : MonoBehaviour
{
    [SerializeField] private int fragmentsRequired = 4; // 1 tutorial level + 3 Forest level.
    [SerializeField] private int currentFragments;
    [SerializeField] private GameObject bossPortalDoorClosed,bossPortalDoorOpen;
    //[SerializeField] private bool hasPlayerReachedCastle = false; // add in later.
    
    private bool isDoorOpen = false; // Do once

    private void Update()
    {
        currentFragments = GameManager.Instance.GetFragments();
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
