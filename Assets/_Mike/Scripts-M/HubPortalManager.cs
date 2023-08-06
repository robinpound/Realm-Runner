using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPortalManager : MonoBehaviour
{
    [Header("Debugs")]
    [SerializeField] private int fragmentsRequired = 4; // 1 tutorial level + 3 Forest level.
    [SerializeField] private int currentFragments;
    [Header("Game Object References, Put In")]
    [SerializeField] private GameObject bossPortalDoorClosed;
    [SerializeField] private GameObject bossPortalDoorOpen;
    [Tooltip("Attach light trail off and on game objects to corrosponding fields")]
    [SerializeField] private GameObject lightToBossPortalOff,lightToBossPortalOn;
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
