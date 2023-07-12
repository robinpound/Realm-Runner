using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [Header("Game Manager Object")]
    public GameObject gameManager;

    [Header("End Game Screen Object")]
    [Tooltip("Only Apply this script to boss realm Canvas or Player.")]
    public GameObject endGameScrn;
    public bool mainBossDead;

    [Header("Coin Display Vars")]
    public int coinCount;
    public Text coins;

    [Header("Fragment Display Vars")]
    public int fragCount;
    public Text fragments;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        endGameScrn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        coinCount = gameManager.GetComponent<GameManager>().coins;
        fragCount = gameManager.GetComponent<GameManager>().fragments;
        coins.text = coinCount.ToString();
        fragments.text = fragCount.ToString();
        if (mainBossDead)
        {
            endGameScrn.SetActive(true);
        }
    }
}
