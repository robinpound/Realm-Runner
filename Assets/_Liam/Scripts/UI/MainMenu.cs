using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject[] options;
    [SerializeField] GameObject credits;
    [SerializeField] Scrollbar bar;

    [SerializeField] bool optionsOpen;
    [SerializeField] bool creditsOpen;



    private void Start()
    {
        credits.SetActive(false);
        options[0].SetActive(false); //Main Options
        options[1].SetActive(false); //Key Bindings Page
        options[2].SetActive(false); //Audio Page
        options[3].SetActive(false); //Video Page
    }

    #region Main Menu Buttons
    // Function to start the game, by loading the relevant starting scene
    public void Begin()
    {
        SceneManager.LoadScene("Rev1TutorialLevelWithAssets");
    }
    // Function to Load Game, using persistent data
    public void LoadGame()
    {
        // Link to Load Function
    }
    // Function to open and close the Options page
    public void Options()
    {
        // If statement to detact whether options page is open or closed
        if (!optionsOpen)
        {
            optionsOpen = true;
            creditsOpen = false;
            options[0].SetActive(true);
            options[1].SetActive(true);
            credits.SetActive(false);
        }
        else if (optionsOpen)
        {
            optionsOpen = false;
            options[0].SetActive(false);
            options[1].SetActive(false);
            options[2].SetActive(false);
            options[3].SetActive(false);
        }
    }
    // Function to Open and Close Credits Page
    public void Credits()
    {
        //If Statement to detect whether credit page is open or closed
        if (!creditsOpen)
        {
            // Run things to open credits and close options
            creditsOpen = true;
            optionsOpen = false;
            credits.SetActive(true);
            bar.value = 1;
            options[0].SetActive(false);
            options[1].SetActive(false);
            options[2].SetActive(false);
            options[3].SetActive(false);
        }
        else if (creditsOpen)
        {
            // Run things to close credits page
            creditsOpen = false;
            credits.SetActive(false);
        }
    }
    // Function to Exit Application
    public void Exit()
    {
        //Code to exit application
        Application.Quit();
    }
    #endregion

    #region Credit Buttons
    // Funstions linking game to everyone's gaming profiles
    public void Mike()
    {
        Application.OpenURL("https://mikehayes.itch.io");
    }
    public void Robin()
    {
        Application.OpenURL("https://robinpound.itch.io");
    }
    public void Jesus()
    {
        Application.OpenURL("https://j-misterio1.itch.io/");
    }
    public void Liam()
    {
        Application.OpenURL("https://9zbp24iuonbfvzf5xzpdaw.on.drv.tw/www.Liams-Gaming-Portfolio.com/Index.html");
    }
    public void Lani()
    {
        Application.OpenURL("https://laniproductions.wixsite.com/my-site");
    }
    // Functions Below linking game assets to the Unity 
    public void Bonk()
    {
        Application.OpenURL("https://assetstore.unity.com/packages/2d/gui/rpg-fantasy-mobile-gui-with-source-files-166086");
    }
    // Function to close the credits age
    public void CreditBack()
    {
        credits.SetActive(false);
    }
    #endregion

    #region Options
    // Function to Open Keybindings Page
    public void KeyBindings()
    {
        options[1].SetActive(true);
        options[2].SetActive(false);
        options[3].SetActive(false);
    }
    // Function to Open Audio Page
    public void Audio()
    {
        options[2].SetActive(true);
        options[1].SetActive(false);
        options[3].SetActive(false);
    }
    // Function to Open Video Page
    public void Video()
    {
        options[3].SetActive(true);
        options[1].SetActive(false);
        options[2].SetActive(false);
    }

    #endregion
}
