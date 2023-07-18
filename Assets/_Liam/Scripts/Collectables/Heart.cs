using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] int health;

    // Start is called before the first frame update
    void Start()
    {
        //Sets Health Pick up to one Heart / Health
        health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotates the Object Pickup
        transform.Rotate(0, 100*Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Runs pickup for the collectable.
        if(other.tag == "Player")
        {

            player.GetComponent<PlayerStats>().AddHealth(health);
            Destroy(gameObject, 0.5f);
        }
    }
}
