using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRespawn : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPoint, player;

    private void Update()
    {
        Debug.Log(spawnPoint.transform.position + " Spawn point poistion");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + " hit the water");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.tag + " spawned at new point");
        
            player.transform.position = spawnPoint.transform.position;
        }
    }
}
