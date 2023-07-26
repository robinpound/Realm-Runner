using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Edited by Mike & Miguel

public class WaterRespawn : MonoBehaviour
{
    [SerializeField]
    private Transform player, spawnPoint, castleSpawnPoint;
    PlayerGravity gravity;
    PlayerCharacterController controller;

    private void Start()
    {
        gravity = player.GetComponent<PlayerGravity>();
        controller = player.GetComponent<PlayerCharacterController>();

    }


    private void Update()
    {
        //Debug.Log(spawnPoint.transform.position + " Spawn point poistion");
        if (Input.GetKeyDown(KeyCode.L)) 
        {
            DebugRespawn();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag + " hit the water");
        if (other.gameObject.CompareTag("Player") && gravity.currentMovement.y > -9.8)
        {
            Debug.Log(other.tag + " spawned at new point");
            //gravity.currentMovement.y = 0;
            controller.controller.enabled = false;

            //player.position += new Vector3(spawnPoint.position.x, player.position.y, spawnPoint.position.z);
            player.position = spawnPoint.position;
            Debug.Log("GRAVITY..." + gravity.currentMovement.y);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log(player.position + " Spawn point poistion");
            //player.GetComponent<PlayerStats>().InstaDead();
            controller.controller.enabled = true;
        }
    }

    private void DebugRespawn()
    {
        controller.controller.enabled = false;

        //player.position += new Vector3(spawnPoint.position.x, player.position.y, spawnPoint.position.z);
        player.position = castleSpawnPoint.position;
        Debug.Log("GRAVITY..." + gravity.currentMovement.y);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log(player.position + " Spawn point poistion");
        //player.GetComponent<PlayerStats>().InstaDead();
        controller.controller.enabled = true;
    }

   
}
