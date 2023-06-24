using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindRandomSpawnPoint : MonoBehaviour
{
    private Vector3 instantiatePosition;

    [Header("Spawner Settings")]
    [Tooltip("Set a random max float value, which will be added to the mid spawn point transform position.")]
    [SerializeField]
    private float randomMaxValue;
    [Tooltip("Set a random min float value, which will be added to the mid spawn point transform position.")]
    [SerializeField]
    private float randomMinValue;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Transform midSpawnPoint;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            Debug.Log("Key has been pressed");
            Debug.Log("random position = " + instantiatePosition);

            findRandomPosition();
            if (instantiatePosition != null)
            {
                Debug.Log("Target Instantiated");
                Instantiate(target, instantiatePosition, Quaternion.identity);
            }
            else return;
        }
    }

    private void findRandomPosition()
    {
        float randomX = UnityEngine.Random.Range(randomMinValue, randomMaxValue);
        float randomY = UnityEngine.Random.Range(randomMinValue, randomMaxValue);
        float randomZ = UnityEngine.Random.Range(randomMinValue, randomMaxValue);
        // Set new random position using random number + mid spawn point position.
        instantiatePosition = new Vector3(midSpawnPoint.position.x + randomX,
            midSpawnPoint.position.y + randomY,
            midSpawnPoint.position.z + randomZ);
    }

    private void OnDrawGizmos()
    {
        // Draw cube for spawn area depending on values inputted.
    }
}
