using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterRespawn : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private void Update()
    {
        //Debug.Log(spawnPoint.transform.position + " Spawn point poistion");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + " hit the water");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.tag + " spawned at new point");

            //player.position += new Vector3(spawnPoint.position.x, player.position.y, spawnPoint.position.z);
            //player.position = spawnPoint.position;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            player.GetComponent<PlayerStats>().InstaDead();
        }
    }
}
