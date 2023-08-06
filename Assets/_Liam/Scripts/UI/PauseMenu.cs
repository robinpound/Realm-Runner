using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerUI;
    [SerializeField] GameObject[] options;

    // Start is called before the first frame update
    void Start()
    {
        // Grabbing the in-game objects
        player = GameObject.FindGameObjectWithTag("Player");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        // Setting Pause Menu it inactive
        pauseMenu.SetActive(false);
        options[0].SetActive(false); //Main Options
        options[1].SetActive(false); //Key Bindings Page
        options[2].SetActive(false); //Audio Page
        options[3].SetActive(false); //Video Page

    }

    #region Pause Menu Buttons
    // Function to Pause the Game
    public void Pause()
    {
        // Stting PM to true and Player UI to false
        pauseMenu.SetActive(true);
        playerUI.SetActive(false);
        // Un-Locking Cursor, setting to visible, and stopping time so player doesn't get attacked whilst paused.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }
    // Function to resume game
    public void Resume()
    {
        // Setting PM to inactive
        pauseMenu.SetActive(false);
        // Locking Cursor, restarting time and cursor to invisible
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        // Setting pause bool to false
        player.GetComponent<PauseActivate>().paused = false;
        // Setting player UI and options menu to inactive
        #region PM UI
        playerUI.SetActive(true);
        pauseMenu.SetActive(false);
        options[0].SetActive(false); //Main Options
        options[1].SetActive(false); //Key Bindings Page
        options[2].SetActive(false); //Audio Page
        options[3].SetActive(false); //Video Page
        #endregion
    }
    // Function to Save the Game using persistent data
    public void SaveGame()
    {
        //Save Game Link / Code here.
        gameManager.GetComponent<GameManager>().SaveProgress();
    }
    // Function to open the Options Menu
    public void Options()
    {
        // Setting Pause Menu false and options to active
        pauseMenu.SetActive(false);
        options[0].SetActive(true);
        options[1].SetActive(true);
    }
    // Function to quit game to the main menu
    public void ExitMainMenu()
    {
        player.GetComponent<PauseActivate>().paused = false;
        Cursor.visible = true;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        SaveGame();
        SceneManager.LoadScene("MainMenu");
    }
    // Function to exit the game to Desktop
    public void ExitDesktop()
    {
        SaveGame();
        Application.Quit();
    }
    #endregion

    #region Options Buttons
    // Function to close the options menu
    public void OptionsBack()
    {
        // Setting PM true and Options menu false
        pauseMenu.SetActive(true);
        options[0].SetActive(false); //Main Options
        options[1].SetActive(false); //Key Bindings Page
        options[2].SetActive(false); //Audio Page
        options[3].SetActive(false); //Video Page
    }
    // Function to open Keybindings Page
    public void KeyBindings()
    {
        // Closes Audio and Video pages whilst opening Keybindings page
        options[1].SetActive(true); //Key Bindings Page
        options[2].SetActive(false); //Audio Page
        options[3].SetActive(false); //Video Page
    }
    // Function to open Audio Page
    public void Audio()
    {
        // Closes keybinding and Video pages whilst opening Audio page
        options[1].SetActive(false); //Key Bindings Page
        options[2].SetActive(true); //Audio Page
        options[3].SetActive(false); //Video Page
    }
    // Function to open Audio Page
    public void Video()
    {
        // Closes Keybindings and Audi pages whilst opening Video page
        options[1].SetActive(false); //Key Bindings Page
        options[2].SetActive(false); //Audio Page
        options[3].SetActive(true); //Video Page
    }
    #endregion
}
