using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollectable : MonoBehaviour
{
    public GameObject player;
    public GameObject heart;
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
        health = player.GetComponent<PlayerUIHealth>().health;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("In!");
        if (other.tag == "Player")
        {
            //Debug.Log("In!");
            if(health < 5)
            {
                player.GetComponent<PlayerUIHealth>().health++;
                GameObject.Destroy(heart);
            }
        }
    }
}
