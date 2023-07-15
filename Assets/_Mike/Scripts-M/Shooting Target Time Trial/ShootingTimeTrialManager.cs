using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private FindTargetSpawnPoint targetSpawn;
   
    private bool stopTimer = false;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject fragment;
    [SerializeField]
    private UIManager ui;

    [Header("Timer Settings")]
    [Tooltip("Set Timer Amount in Seconds")]
    [SerializeField]
    private float timeRemaining = 10f;

    // Change to event later.
    public bool isTrialRunning = false;
    [SerializeField]
    private bool fragmentSpawned = false; // Dont spawn fragment again

    private void Start()
    {
        targetSpawn = GetComponent<FindTargetSpawnPoint>();
        pointsToWin = targetSpawn.targetsInTrial;

        ui = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        //Debug.Log("Player has " + points + " Points");
        if (points >= pointsToWin)
        {
            OnPlayerWins();
        }
        if (timeRemaining <= 0) 
        {
            Debug.Log("Player Loses, game resets");
            Invoke(nameof(ResetAttack), .1f); // Allow player to play trail again.
        }
    }

    private void OnPlayerWins()
    {
        Debug.Log("The Player Beat The Time Trial");
        stopTimer = true;
        ui.HideTimer();
        PlayPuzzleCompleteSound();
        ui.PlayerWinsShootingTrail(); // Show winning text in player UI.
        if (!fragmentSpawned)
        {
            SpawnFragment();
            fragmentSpawned = true;
        }
        else return;
        Invoke(nameof(ResetAttack), .1f); // Allow player to play trail again.
    }

    private void SpawnFragment()
    {
        Instantiate(fragment, spawnPoint.position, Quaternion.identity);

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
            ui.HideTimer();
            //points= 0; // Reset points.
        }
        ui.ShowTimer();
        ui.DisplayTimeRemaining(timeRemaining);
    }

    public int pointsAdded(int pointsGained)
    {
        Debug.Log("Player +1 Points");
        points += pointsGained;
        return pointsGained;
    }

    private void PlayPuzzleCompleteSound()
    {
        Debug.Log("play puzzle win sound");
        FindObjectOfType<AudioManager>().PlaySound("PuzzleWon");
    }

    

    private void ResetAttack()
    {
        isTrialRunning = false;
    }
}
