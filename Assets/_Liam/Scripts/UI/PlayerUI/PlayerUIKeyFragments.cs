using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIKeyFragments : MonoBehaviour
{
    public GameObject gameManager;
    public int fragmentsInt;
    public Text display;

    // Start is called before the first frame update
    void Start()
    {
        //gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        //fragmentsInt = gameManager.GetComponent<GameManager>().fragments;
        if (Input.GetKeyDown(KeyCode.E))
        {
            //gameManager.GetComponent<GameManager>().CollectFragments();
        }

        display.text = fragmentsInt.ToString();
    }
}
