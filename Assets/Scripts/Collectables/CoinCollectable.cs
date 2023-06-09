using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectable : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject coin;
    public int coins;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("In!");
        if(other.tag == "Player")
        {
            Debug.Log("In!");
            gameManager.GetComponent<GameManager>().coins++;
            GameObject.Destroy(coin);
        }
    }
}
