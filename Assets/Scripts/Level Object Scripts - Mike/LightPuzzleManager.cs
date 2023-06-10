using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightPuzzleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cubes;
    private List<bool> cubesInPuzzleLightStatus = new List<bool>();

    private void Update()
    {
        // Find boolean for light status for each cube in the list and add it to a new bool list.
        int numberOfCubesInPuzzle = cubes.Length;
        foreach (GameObject i in cubes)
        {
            bool iLightsStatus = gameObject.GetComponent<LightUpGridPuzzle>().hasLightSpawned;
            cubesInPuzzleLightStatus.Add(iLightsStatus);
            

        }

        // If all the booleans return true in the new list, the puzzle is completed.
        

    }

}
