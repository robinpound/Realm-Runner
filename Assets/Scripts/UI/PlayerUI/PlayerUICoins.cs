using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUICoins : MonoBehaviour
{
    public Text coinText;
    public int coins;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            coins += 1;
        }

        coinText.text = coins.ToString();
    }
}
