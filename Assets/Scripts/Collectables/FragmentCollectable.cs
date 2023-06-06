using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentCollectable : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;
    public GameObject fragment;
    public bool collected;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        collected = gameManager.GetComponent<GameManager>().fragmentBool[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("In!");
        if (other.tag == "Player")
        {
            Debug.Log("In!");
            //player.GetComponent<PlayerUIKeyFragments>().fragmentsInt++;
            gameManager.GetComponent<GameManager>().fragmentsTotal++;
            gameManager.GetComponent<GameManager>().levelFragments++;
            //gameManager.GetComponent<GameManager>().fragmentBool[0] = true;
            GameObject.Destroy(fragment);
        }
    }
}
