using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using System.Runtime.CompilerServices;
using UnityEngine.Events;

public class ShootingTimeTrialManager : MonoBehaviour
{
    [Header("Debugs")]
    [SerializeField]
    private int points = 0;
    [SerializeField]
    private int pointsToWin;
    private FindTargetSpawnPoint targetSpawn;
   
    private bool stopTimer = false;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private GameObject fragment;
    private UIManager ui;

    [Header("Timer Settings")]
    [Tooltip("Set Timer Amount in Seconds")]
    [SerializeField]
    private float timeRemaining = 10f;

    [Header("Events")]
    [SerializeField] UnityEvent lightUpStatue;
    // Change isTrialRunning bool to event later.
    public bool isTrialRunning = false; // Only read in interact to stop trial being played more than once at one time.
    private bool fragmentSpawned = false; // Do once
    private bool isTimerSoundPlaying = false;
    private bool isWinSoundPlaying = false;

    private AudioSource timerSound;


    private void Start()
    {
        targetSpawn = GetComponent<FindTargetSpawnPoint>();
        pointsToWin = targetSpawn.targetsInTrial;

        ui = FindObjectOfType<UIManager>();

        timerSound = GetComponent<AudioSource>(); // Change later!!
    }

    private void Update()
    {
        //Debug.Log("Player has " + points + " Points");
        if (points >= pointsToWin && isTrialRunning)
        {
            OnPlayerWins();
        }
        if (timeRemaining <= 0 && isTrialRunning) // End the time trial.
        {
            OnPlayerFails();
        }
    }

    private void OnPlayerWins()
    {
        Debug.Log("The Player Beat The Time Trial");
        stopTimer = true;
        ui.HideTimer();
        StopTimerSound();
        PlayPuzzleCompleteSound();
        ui.PlayerWinsShootingTrail(); // Show winning text in player UI.
        Invoke(nameof(ResetTrial), .1f);
        lightUpStatue.Invoke();
        if (!fragmentSpawned)
        {
            SpawnFragment();
            fragmentSpawned = true;
        }
        
    }

    private void OnPlayerFails()
    {
        Debug.Log("Player Loses, game resets");
        ui.HideTimer();
        StopTimerSound();
        Invoke(nameof(ResetTrial), .1f);
    }

    private void SpawnFragment()
    {
        Instantiate(fragment, spawnPoint.position, Quaternion.identity);

    }

    public void Timer()
    {
        Debug.Log("Timer is running");

        if (!stopTimer && timeRemaining > 0)
        {
            isTrialRunning = true;
            timeRemaining -= Time.deltaTime;
            //Debug.Log("Time remaining = " + timeRemaining);
            ui.ShowTimer();
            ui.DisplayTimeRemaining(timeRemaining);
            PlayTimerSound();
        }
        else
        {
            isTrialRunning= false;
            Debug.Log("++Timer Finished");
            timeRemaining = 0;
            ui.HideTimer();
            //points= 0; // Reset points.
        }
        
    }

    public int pointsAdded(int pointsGained)
    {
        Debug.Log("Player +1 Points");
        points += pointsGained;
        return pointsGained;
    }

    private void PlayTimerSound()
    {
        if (isTrialRunning && !isTimerSoundPlaying)
        {
            isTimerSoundPlaying = true;
            timerSound.Play();
        }
    }

    private void StopTimerSound()
    {
        if (isTimerSoundPlaying)
        {
            isTimerSoundPlaying = false;
            timerSound.Stop();

        }
    }
    private void PlayPuzzleCompleteSound()
    {
        //Debug.Log("play puzzle win sound");
        if (!isWinSoundPlaying)
        {
            isWinSoundPlaying = true;
            FindObjectOfType<AudioManager>().PlaySound("PuzzleWon");
        }
        
    }



    private void ResetTrial()
    {
        points = 0;
        // Add Destroy all current targets that if they currently exist.
    }
}
