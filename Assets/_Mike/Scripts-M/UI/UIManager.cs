using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject gameManager;
    private GameManager _gameManager;
    private const string GAMEMANAGERTAG = "GameManager";

    [Header("Text Debugs")]
    [SerializeField]
    private TextMeshProUGUI coins, fragments;


    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag(GAMEMANAGERTAG);
        _gameManager = gameManager.GetComponent<GameManager>();
    }

    private void Update()
    {
        coins.text = _gameManager.coins.ToString();
        fragments.text = _gameManager.fragments.ToString();
    }
}
