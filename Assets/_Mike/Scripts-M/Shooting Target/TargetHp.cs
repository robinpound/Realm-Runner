using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHp : MonoBehaviour
{
    [SerializeField]
    private ShootingTimeTrialManager manager;

    private int pointsAdded = 1; // Points added when the player destroys a target.

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            // Add points to manager
            manager.pointsAdded(pointsAdded);
            Destroy(gameObject);
        }
    }
}
