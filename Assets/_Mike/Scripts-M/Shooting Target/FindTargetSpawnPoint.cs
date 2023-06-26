using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FindTargetSpawnPoint : MonoBehaviour
{ 
    [Header("Spawner Settings")]
    [Tooltip("Set the spawn positions of each possible target (MAX = 6). Edit transform position of child objects under Spawn Positions")]
    [SerializeField] Transform[] targetSpawnPoints = new Transform[6];
    [Tooltip("Set how many targets will spawn in this trial (MAX = 6).")]
    [SerializeField]
    private int targetsInTrial;
   
    [SerializeField]
    private GameObject target;
    
    

    private void Start()
    {
        
    }
    private void Update()
    {

        if (Input.GetKeyUp(KeyCode.K))
        {
            Debug.Log("Key has been pressed");
            
            // Go through list of vectors postions to instantiate a target at a random position.
            for (int i = 0; i < targetsInTrial; i++)
            {
                //int randomIndex = Random.Range(0, targetSpawnPoints.Length); // Targets can spawn in same position.

                Debug.Log("Target Instantiated at " + transform.position);
                Instantiate(target, targetSpawnPoints[i].position, Quaternion.identity);
            }
            
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
