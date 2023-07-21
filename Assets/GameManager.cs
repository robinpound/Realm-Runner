using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

// Edited by Mike.

public class GameManager : MonoBehaviour
{
    private string savePath; // Path to the JSON save file
    private GameObject player;
    [SerializeField]
    private GameObject portalDoor;
    [SerializeField]
    private UIManager ui;
    public int deathCount;
    public int coins;
    public int fragments;
    public int currentLevel;
    public int currentCheckpoint;

    private bool isPortalOpened = false;

    private const string PLAYERTAG = "Player", PORTALDOOR = "PortalDoor";

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(PLAYERTAG);
        // Reset coins and fragments on start.
        coins = 0;
        fragments = 0;
        savePath = Application.persistentDataPath + "/playerProgress.json"; // Set the path to the JSON save file
    }

    private void Update()
    {
        //portalDoor = GameObject.Find("Portal door");
        if (portalDoor == null)
        {
            portalDoor = GameObject.Find("Portal door");
            portalDoor.SetActive(false);
        }
        if (fragments >= 2 && !isPortalOpened)
        {
            isPortalOpened = true;
            portalDoor.SetActive(true);
            ui.TellPlayerPortalIsOpen();
        }
        DontDestroyOnLoad(gameObject);
    }

    public int CoinCollected(int coinValue)
    {
        coins += coinValue;
        return coins;
    }

    public void SaveProgress()
    {
        PlayerProgressData progressData = new PlayerProgressData(coins, fragments, currentLevel, currentCheckpoint, deathCount); // Create a data object with the player's progress
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
            currentLevel = progressData.currentLevel;
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
    public int currentLevel;
    public int currentCheckpoint;
    public int deathCount;
    public PlayerProgressData(int coins, int fragments, int currentLevel, int currentCheckpoint, int deathCount)
    {
        this.coins = coins;
        this.fragments = fragments;
        this.currentLevel = currentLevel;
        this.currentCheckpoint = currentCheckpoint;
        this.deathCount = deathCount;
    }
}