using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] fragments;
    private GameObject gameManager;
    private GameManager _gameManager;
    private const string GAMEMANAGERTAG = "GameManager";

    [Header("Text Debugs")]
    [SerializeField]
    private TextMeshProUGUI coins;
    [SerializeField] private int fragmentsCollected;

    [SerializeField] private int arraypos;

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
        fragmentsCollected = _gameManager.fragments;
        Fragment();
    }

    private void Fragment()
    {
        if(fragmentsCollected == 1)
        {
            fragments[0].SetActive(true);
        }
        else if (fragmentsCollected == 2)
        {
            fragments[1].SetActive(true);
        }
        else if (fragmentsCollected == 3)
        {
            fragments[2].SetActive(true);
        }
        else if (fragmentsCollected == 4)
        {
            fragments[3].SetActive(true);
        }
        else if (fragmentsCollected == 5)
        {
            fragments[4].SetActive(true);
        }
        else if (fragmentsCollected == 6)
        {
            fragments[5].SetActive(true);
        }
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
