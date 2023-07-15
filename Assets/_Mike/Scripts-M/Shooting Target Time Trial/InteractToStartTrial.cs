using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractToStartTrial : MonoBehaviour
{
    [Header("Debugs")]
    [SerializeField]
    private InteractableArea interactableArea;
    
    private FindTargetSpawnPoint spawn;
    private ShootingTimeTrialManager manager;
    

    private void Start()
    {
        spawn = GetComponent<FindTargetSpawnPoint>();   
        manager = GetComponent<ShootingTimeTrialManager>();
    }
    private void Update()
    {
        if (interactableArea.canPlayerInteract && Input.GetKeyDown(KeyCode.E)
            && !manager.isTrialRunning) // Change to input settings
        {
            spawn.StartTrial();
        }
    }

    
}
