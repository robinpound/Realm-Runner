using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestPotalToCastle : MonoBehaviour
{
    [SerializeField]
    private Transform player, castleSpawnPoint;
    PlayerCharacterController controller;

    private const string PLAYERTAG = "Player";

    private void Start()
    {
        controller = player.GetComponent<PlayerCharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYERTAG))
        {
            controller.controller.enabled = false;
            player.position = castleSpawnPoint.position;
            controller.controller.enabled = true;
        }
    }
}
