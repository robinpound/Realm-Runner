using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHp : MonoBehaviour
{
    [SerializeField]
    private ShootingTimeTrialManager manager;
    private GameObject _manager;
    private const string MANAGERTAG = "ShootingTrialManager";
    private const string ARROW = "Arrow";

    private int pointsAdded = 1; // Points added when the player destroys a target.

    private void Update()
    {
        // Set target clones as child of manager game object
        //transform.parent.gameObject.GetComponent<ShootingTimeTrialManager>();
       
       
        _manager = GameObject.FindGameObjectWithTag(MANAGERTAG);
        manager = _manager.GetComponent<ShootingTimeTrialManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag(ARROW))
        {
            // Add points to manager
            manager.pointsAdded(pointsAdded);
            PlayPopSound();
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void PlayPopSound()
    {
        FindObjectOfType<AudioManager>().PlaySound("BalloonPopped");
    }
}
