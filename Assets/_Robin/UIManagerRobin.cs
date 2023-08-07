using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManagerRobin : MonoBehaviour
{
    GameObject gameManager;
    [SerializeField] int coin;
    [SerializeField] TMP_Text coinNumberText;
    [SerializeField] int fragments;
    [SerializeField] TMP_Text FragmentNumberText;

    private void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        fragments = gameManager.GetComponent<GameManager>().GetFragments();
        coin = gameManager.GetComponent<GameManager>().GetCoins();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void Update()
    {
        coinNumberText.text = coin.ToString();
        FragmentNumberText.text = fragments.ToString();
    }
    public void ExitGame() 
    {
        SceneManager.LoadScene("MainMenu");
    }


}
