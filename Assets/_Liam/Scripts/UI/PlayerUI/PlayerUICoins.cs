using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUICoins : MonoBehaviour
{
    public GameObject gameManager;
    public Text coinText;
    public int coins;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        coins = gameManager.GetComponent<GameManager>().coins;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameManager.GetComponent<GameManager>().coins++;
        }

        coinText.text = coins.ToString();
    }
}
