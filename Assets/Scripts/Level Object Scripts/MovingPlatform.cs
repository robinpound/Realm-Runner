using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform waypointA, waypointB;
    
    private float platformLerpSpeed = .5f;
    private enum PlatformDirectionSM { toPointA, toPointB }
    private PlatformDirectionSM direction = PlatformDirectionSM.toPointA;

    private Transform tempTransform;
    private GameObject player;


    private void FixedUpdate()
    {
        float distanceToWaypointA = Vector3.Distance(transform.position, waypointA.position);
        //Debug.Log("Distance to waypoint A " + distanceToWaypointA);
        float distanceToWaypointB = Vector3.Distance(transform.position, waypointB.position);
        //Debug.Log("Distance to waypoint B " + distanceToWaypointB);

        switch (direction)
        {
            case PlatformDirectionSM.toPointA:
                MovePlatformToWaypointA();
                float switchFromWaypointAThreshold = 1f;
                if (distanceToWaypointA < switchFromWaypointAThreshold)
                    direction = PlatformDirectionSM.toPointB;
                break;

            case PlatformDirectionSM.toPointB:
                MovePlatformToWaypointB();
                float switchFromWaypointBThreshold = 1.5f;
                if (distanceToWaypointB < switchFromWaypointBThreshold)
                    direction = PlatformDirectionSM.toPointA;
                break;
        }
            
    }
  
    private void MovePlatformToWaypointA()
    {
        //Debug.Log("Platform is moving");
        //transform.Translate(waypointA.transform.position * platformLerpSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, waypointA.position, platformLerpSpeed * Time.deltaTime);
    }
    private void MovePlatformToWaypointB()
    {
        //Debug.Log("Platform is moving");
        //transform.Translate(waypointB.transform.position * platformLerpSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, waypointB.position, platformLerpSpeed * Time.deltaTime);
    }

    // Check if player is on platform and then change it to a child of the moving platform.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collison with " + collision.gameObject.name);
            ChangeParentofPlayerObjectToThis();
        }
        else return;
    }

    // Store player parent into the temp transform variable.
    // Set the player to a child of this game object.
    void ChangeParentofPlayerObjectToThis()
    {
        Debug.Log("Set player as child of moving platform");
        tempTransform = player.transform.parent;
        player.transform.parent = transform;
    }

    //Revert the parent of the player.
    void RevertParent()
    {
        player.transform.parent = tempTransform;
    }
}
