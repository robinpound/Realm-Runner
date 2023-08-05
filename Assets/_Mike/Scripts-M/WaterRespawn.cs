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

    private const string PLAYERTAG = "Player";

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
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("current movement on Y axis = " + gravity.currentMovement.y + " // -9.8");
        Debug.Log(other.tag + " hit the water");
        if (other.gameObject.CompareTag(PLAYERTAG) && gravity.currentMovement.y < -9.8)
        {
            //Debug.Log(other.tag + " spawned at new point");
            controller.controller.enabled = false;
            player.position = spawnPoint.position;
            //Debug.Log("GRAVITY..." + gravity.currentMovement.y);
            //Debug.Log(player.position + " Spawn point poistion");
            controller.controller.enabled = true;
        }
    }
    

    private void DebugRespawn()
    {
        controller.controller.enabled = false;
        player.position = castleSpawnPoint.position;
        //Debug.Log("GRAVITY..." + gravity.currentMovement.y);
        //Debug.Log(player.position + " Spawn point poistion");
        controller.controller.enabled = true;
    }

   
}
