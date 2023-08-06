using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// Edited by Mike & Liam.

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton
    private string savePath; // Path to the JSON save file
    private GameObject player;
    public int deathCount;
    public int coins;
    public int fragments;
    public int currentCheckpoint;

    private const string PLAYERTAG = "Player", PORTALDOOR = "PortalDoor";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(PLAYERTAG);
        // Reset coins and fragments on start.
        coins = 0;
        fragments = 0;
        savePath = Application.persistentDataPath + "/playerProgress.json"; // Set the path to the JSON save file
    }

    public int CoinCollected(int coinValue)
    {
        coins += coinValue;
        return coins;
    }

    public void AddFragmentsFromLevel(int fragmentsAdded)
    {
        fragments += fragmentsAdded;
    }

    public int GetFragments () { return fragments; }
    public int GetCoins () { return coins; }

    public void SaveProgress()
    {
        PlayerProgressData progressData = new PlayerProgressData(coins, fragments, currentCheckpoint, deathCount); // Create a data object with the player's progress
        string jsonData = JsonUtility.ToJson(progressData); // Convert the data object to JSON
        File.WriteAllText(savePath, jsonData); // Write the JSON data to the save file
    }
    public void LoadProgress()
    {
        if (File.Exists(savePath)) // Check if the save file exists
        {
            string jsonData = File.ReadAllText(savePath); // Read the JSON data from the save file
            PlayerProgressData progressData = JsonUtility.FromJson<PlayerProgressData>(jsonData); // Convert the JSON data to a data object
            coins = progressData.coins; // Set the player's progress based on the data object
            fragments = progressData.fragments;
            currentCheckpoint = progressData.currentCheckpoint;
            deathCount = progressData.deathCount;
        }
    }
}
[System.Serializable]
public class PlayerProgressData
{
    public int coins;
    public int fragments;
    public int currentCheckpoint;
    public int deathCount;
    public PlayerProgressData(int coins, int fragments, int currentCheckpoint, int deathCount)
    {
        this.coins = coins;
        this.fragments = fragments;
        this.currentCheckpoint = currentCheckpoint;
        this.deathCount = deathCount;
    }   
}