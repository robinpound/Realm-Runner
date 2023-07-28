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

    [SerializeField]
    private TextMeshProUGUI timeRemaining, success, portalIsOpen, pressE, pathToCastleIsOpen;

    private bool isFloatingPlatTextShown = false;


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

    public void ShowTimer()
    {
        timeRemaining.gameObject.SetActive(true);
    }

    public void HideTimer() 
    { 
        timeRemaining.gameObject.SetActive(false);
    }

    // Convert timer into minutes and seconds.
    public void DisplayTimeRemaining(float timeDisplay)
    {
        float minutes = Mathf.FloorToInt(timeDisplay / 60);
        float seconds = Mathf.FloorToInt(timeDisplay % 60);
        timeRemaining.text = string.Format("{0:00}:{1:00}", minutes,seconds);
    }

    public void PlayerWinsShootingTrail()
    {
        // Display player wins text
        success.gameObject.SetActive(true);
        StartCoroutine(Timer(success.gameObject));
    }

    public void PressEDisplay()
    {
        pressE.gameObject.SetActive(true);
        StartCoroutine(Timer(pressE.gameObject));
    }

    public void StopEDisplay()
    {
        pressE.gameObject.SetActive(false);
    }

    public void TellPlayerPortalIsOpen()
    {
        portalIsOpen.gameObject.SetActive(true);
        StartCoroutine(Timer(portalIsOpen.gameObject)); // Turn of notice display after timer finishes.
    }

    public void PathToCastleMessage()
    {
        if (!isFloatingPlatTextShown)
        {
            pathToCastleIsOpen.gameObject.SetActive(true);
            StartCoroutine(Timer(pathToCastleIsOpen.gameObject));
            isFloatingPlatTextShown = true;
        }
        
    }
    IEnumerator Timer(GameObject text)
{
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }
}
