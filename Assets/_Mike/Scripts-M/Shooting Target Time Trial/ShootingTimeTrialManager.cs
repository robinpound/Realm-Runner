using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;

public class ShootingTimeTrialManager : MonoBehaviour
{
    [Header("Debugs")]
    [SerializeField]
    private int points = 0;
    [SerializeField]
    private int pointsToWin;
    [SerializeField]
    private TMP_Text timeText, playerWins;
    private FindTargetSpawnPoint targetSpawn;
    private bool stopTimer = false;

    [Header("Timer Settings")]
    [Tooltip("Set Timer Amount in Seconds")]
    [SerializeField]
    private float timeRemaining = 10f;
    

    private void Start()
    {
        targetSpawn = GetComponent<FindTargetSpawnPoint>();
        pointsToWin = targetSpawn.targetsInTrial;
    }

    private void Update()
    {
        //Debug.Log("Player has " + points + " Points");
        if (points >= pointsToWin)
        {
            Debug.Log("The Player Beat The Time Trial");
            stopTimer = true;
            playerWins.gameObject.SetActive(true);
            

            // need to add puzzle triumph script containing + 1 Fragment + PlayTriumphSound
        }
    }

    

    // Timer for time trial
    public void Timer()
    {
        Debug.Log("Time Trail Has Started");

        if (!stopTimer && timeRemaining > 0)
        {

            timeRemaining -= Time.deltaTime;
            //Debug.Log("Time remaining = " + timeRemaining);
            
        }
        else
        {
            Debug.Log("++Timer Finished");
            timeRemaining = 0;
            //points= 0; // Reset points.
        }
        DisplayTimeRemaining(timeRemaining);
    }

    // Convert timer into minutes and seconds.
    private void DisplayTimeRemaining(float timeDisplay)
    {
        float minutes = Mathf.FloorToInt(timeDisplay / 60);
        float seconds = Mathf.FloorToInt(timeDisplay% 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes,seconds);
    }

    public int pointsAdded(int pointsGained)
    {
        Debug.Log("Player +1 Points");
        points += pointsGained;
        return pointsGained;
    }
}
