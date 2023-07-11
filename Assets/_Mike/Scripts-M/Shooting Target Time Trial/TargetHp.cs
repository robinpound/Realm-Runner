using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHp : MonoBehaviour
{
    [SerializeField]
    private ShootingTimeTrialManager manager;
    private GameObject _manager;

    private int pointsAdded = 1; // Points added when the player destroys a target.

    private void Start()
    {
        // Set target clones as child of manager game object
        //transform.parent.gameObject.GetComponent<ShootingTimeTrialManager>();
        _manager = GameObject.FindGameObjectWithTag("Trial");
        manager = _manager.GetComponent<ShootingTimeTrialManager>();
    }

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
