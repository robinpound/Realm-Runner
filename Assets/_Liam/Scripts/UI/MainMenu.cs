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

    public bool optionsOpen;
    public bool creditsOpen;

    private void Start()
    {
        optionsOpen = false;
        credits.SetActive(false);
        options[0].SetActive(false); //Main Options
        options[1].SetActive(false); //Key Bindings Page
        options[2].SetActive(false); //Audio Page
        options[3].SetActive(false); //Video Page
    }

    #region Main Menu Buttons
    public void Begin()
    {
        SceneManager.LoadScene("FirstLevel");
    }
    public void LoadGame()
    {
        // Link to Load Function
    }
    public void Options()
    {
        if (!optionsOpen)
        {
            options[0].SetActive(true);
            options[1].SetActive(true);
            optionsOpen = true;
            credits.SetActive(false);
            creditsOpen = false;
        }
        else if (optionsOpen)
        {
            options[0].SetActive(false);
            options[1].SetActive(false);
            options[2].SetActive(false);
            options[3].SetActive(false);
            optionsOpen = false;
        }
    }
    public void Credits()
    {
        if (!creditsOpen) 
        {
            creditsOpen = true;
            credits.SetActive(true);
            bar.value = 1;
            options[0].SetActive(false);
            options[1].SetActive(false);
            options[2].SetActive(false);
            options[3].SetActive(false);
            optionsOpen = false;
        }
        else if (creditsOpen)
        {
            creditsOpen = false;
            credits.SetActive(false);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
    #endregion

    #region Credit Buttons
    public void Mike()
    {
        Application.OpenURL("");
    }
    public void Robin()
    {
        Application.OpenURL("");
    }
    public void Jesus()
    {
        Application.OpenURL("");
    }
    public void Liam()
    {
        Application.OpenURL("");
    }
    public void CreditBack()
    {
        credits.SetActive(false);
        creditsOpen = false;
    }
    #endregion

    #region Options
    public void OptionsBack()
    {
        options[0].SetActive(false);
        options[1].SetActive(false);
        options[2].SetActive(false);
        options[3].SetActive(false);
        optionsOpen = false;
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
