using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class FindTargetSpawnPoint : MonoBehaviour
{ 
    [Header("Spawner Settings")]
    [Tooltip("Set the spawn positions of each possible target (MAX = 6). Edit transform position of child objects under Spawn Positions")]
    [SerializeField] Transform[] targetSpawnPoints = new Transform[6];
    [Tooltip("Set how many targets will spawn in this trial (MAX = 6).")]
    [SerializeField]
    public int targetsInTrial; // Read in manager
   
    [SerializeField]
    private GameObject target;
    [Tooltip("Select true to activate random spawn order, or false to keep default spawn order (1 ~ 6)")]
    [SerializeField]
    private bool shuffleList;
    // List used to shuffle and choose random spawn order of targets.
    private List<int> indexNumbers = new List<int> { 0, 1, 2, 3, 4, 5};
    [SerializeField]
    private ShootingTimeTrialManager manager;
    private bool startTrial = false;
    

    private void Start()
    {
        manager = GetComponent<ShootingTimeTrialManager>();

        if(shuffleList)
        {
            ShuffleList(indexNumbers);
        }
        
    }
    private void Update()
    {
        if (startTrial == true)
        {
            manager.Timer();
        }
    }

    public void StartTrial()
    {
        Debug.Log("Trial has started");
        startTrial = true;

        // Go through list of vectors postions to instantiate a target at a random position.
        // If shuffle is on, instantiate from shuffled list.
        for (int i = 0; i < targetsInTrial; i++)
        {
            //Debug.Log("Target Instantiated at " + transform.position);
            if (!shuffleList)
            {
                Instantiate(target, targetSpawnPoints[i].position, Quaternion.identity);
            }
            else
            {
                Instantiate(target, targetSpawnPoints[indexNumbers[i]].position, Quaternion.identity);
            }

        }
    }
    
    // Shuffle list using FISHER-YATES SHUFFLE
    private void ShuffleList<T>(List<T> inputList)
    {
        for (int i = 0; i < inputList.Count - 1;i++)
        {
            T temp = inputList[i];
            int random = Random.Range(i, inputList.Count);
            inputList[i] = inputList[random];
            inputList[random] = temp;
        }
    }
    
    // Draw a gizmo at each possible target spawn point in vector3 array.
    private void OnDrawGizmos()
    {
        float sphereSize = .2f;
        for (int i = 0; i < targetSpawnPoints.Length; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(targetSpawnPoints[i].position, sphereSize);
        }
    }
}
