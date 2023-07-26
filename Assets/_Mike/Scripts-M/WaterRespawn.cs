using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterRespawn : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    PlayerGravity gravity;
    public Transform spawnPoint;
    PlayerCharacterController controller;

    private void Start()
    {
        gravity = GetComponent<PlayerGravity>();
        controller = FindObjectOfType<PlayerCharacterController>();

    }

    private void Update()
    {
        //Debug.Log(spawnPoint.transform.position + " Spawn point poistion");
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

        }
    }

    private void OnTriggerExit(Collider other)
    {
        controller.controller.enabled = true;

    }
}
