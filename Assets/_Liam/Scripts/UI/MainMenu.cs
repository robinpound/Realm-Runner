using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject[] options;
    public GameObject credits;
    public Scrollbar bar;

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
    public void Begin()
    {
        SceneManager.LoadScene("Rev1TutorialLevelWithAssets");
    }
    public void LoadGame()
    {
        // Link to Load Function
    }
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
    public void Mike()
    {
        Application.OpenURL("https://mikehayes.itch.io");
    }
    public void Robin()
    {
        Application.OpenURL("https://itch.io/profile/robinpound");
    }
    public void Jesus()
    {
        Application.OpenURL("https://j-misterio1.itch.io/");
    }
    public void Liam()
    {
        Application.OpenURL("https://liamwils20.itch.io");
    }
    public void Lani()
    {
        Application.OpenURL("");
    }
    public void CreditBack()
    {
        credits.SetActive(false);
    }
    #endregion

    #region Options
    public void OptionsBack()
    {
        options[0].SetActive(false);
        options[1].SetActive(false);
        options[2].SetActive(false);
        options[3].SetActive(false);
    }

    public void KeyBindings()
    {
        options[1].SetActive(true);
        options[2].SetActive(false);
        options[3].SetActive(false);
    }
    public void Audio()
    {
        options[2].SetActive(true);
        options[1].SetActive(false);
        options[3].SetActive(false);
    }
    public void Video()
    {
        options[3].SetActive(true);
        options[1].SetActive(false);
        options[2].SetActive(false);
    }

    #endregion
}
