using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractToStartTrial : MonoBehaviour
{
    [Header("Debugs")]
    [SerializeField]
    private InteractableArea interactableArea;
    
    private FindTargetSpawnPoint spawn;
    

    private void Start()
    {
        spawn = GetComponent<FindTargetSpawnPoint>();   
    }
    private void Update()
    {
        if (interactableArea.canPlayerInteract && Input.GetKeyDown(KeyCode.N)) // Change to input settings
        {
            spawn.StartTrial();
        }
    }

    
}
