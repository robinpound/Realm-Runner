using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentCollectable : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;
    public GameObject fragment;

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
        if (other.tag == "Player")
        {
            Debug.Log("In!");
            player.GetComponent<PlayerUIKeyFragments>().fragmentsInt++;
            gameManager.GetComponent<GameManager>().fragments++;
            GameObject.Destroy(fragment);
        }
    }
}
