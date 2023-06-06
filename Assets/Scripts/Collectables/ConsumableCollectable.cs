using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableCollectable : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;
    public GameObject consumable;
    public bool one;
    public bool two;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
        one = player.GetComponent<Inventory>().slot1Bool;
        two = player.GetComponent<Inventory>().slot2Bool;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("In!");
        if (other.tag == "Player")
        {
            Debug.Log("In!");
            if (one != true)
            {
                player.GetComponent<Inventory>().arrayPos1++;
                player.GetComponent<Inventory>().SpawnObjects();
                GameObject.Destroy(consumable);
            }
            if (two != true && one == true)
            {
                player.GetComponent<Inventory>().arrayPos2++;
                player.GetComponent<Inventory>().SpawnObjects();
                GameObject.Destroy(consumable);
            }
        }
    }
}
