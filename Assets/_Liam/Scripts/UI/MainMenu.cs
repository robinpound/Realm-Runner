using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // This Script is to host all Main Menu UI Buttons

    [SerializeField] GameObject[] options;
    [SerializeField] GameObject credits;
    [SerializeField] Scrollbar bar;

    private void Start()
    {
        // Deactivates Credits and Options pages
        credits.SetActive(false);
        options[0].SetActive(false); //Main Options
        options[1].SetActive(false); //Key Bindings Page
        options[2].SetActive(false); //Audio Page
        options[3].SetActive(false); //Video Page
    }
    // Region for the Main Menu Functions
    #region Main Menu Buttons
    // Function to begin playing the game. A new game
    public void Begin()
    {
        SceneManager.LoadScene("Rev1TutorialLevelWithAssets");
    }
    // Function to load the game, for persistent data
    public void LoadGame()
    {
        // Link to Load Function
    }
    // Function to open the Options Page, and Keybindings page
    public void Options()
    {
        options[0].SetActive(true);
        options[1].SetActive(true);
    }
    // Function to open the Credits page
    public void Credits()
    {
        credits.SetActive(true);
        bar.value = 1;
    }
    // Function to exit the game
    public void Exit()
    {
        Application.Quit();
    }
    #endregion

    // Region for the Credit Menu Functions
    #region Credit Buttons
    // Function to head to Mikes Itch.Io
    public void Mike()
    {
        Application.OpenURL("https://mikehayes.itch.io");
    }
    // Function to head to Robins Itch.Io
    public void Robin()
    {
        Application.OpenURL("https://itch.io/profile/robinpound");
    }
    // Function to head to Jesus Itch.Io
    public void Jesus()
    {
        Application.OpenURL("");
    }
    // Function to head to Liam Itch.Io
    public void Liam()
    {
        Application.OpenURL("https://liamwils20.itch.io");
    }
    // Function to close the Credit Page
    public void CreditBack()
    {
        credits.SetActive(false);
    }
    #endregion

    // Region for the Options Menu Functions
    #region Options
    // Options function to close the options page
    public void OptionsBack()
    {
        options[0].SetActive(false);
        options[1].SetActive(false);
        options[2].SetActive(false);
        options[3].SetActive(false);
    }
    // Function to open Keybindings and close other tabs
    public void KeyBindings()
    {
        options[1].SetActive(true);
        options[2].SetActive(false);
        options[3].SetActive(false);
    }
    // Function to open Audio and close other tabs
    public void Audio()
    {
        options[2].SetActive(true);
        options[1].SetActive(false);
        options[3].SetActive(false);
    }
    // Function to open Video and close other tabs
    public void Video()
    {
        options[3].SetActive(true);
        options[1].SetActive(false);
        options[2].SetActive(false);
    }

    #endregion
}
