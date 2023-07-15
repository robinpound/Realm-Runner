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
        options[0].SetActive(true);
        options[1].SetActive(true);
    }
    public void Credits()
    {
        credits.SetActive(true);
        bar.value = 1;
    }
    public void Exit()
    {
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
        Application.OpenURL("");
    }
    public void Liam()
    {
        Application.OpenURL("https://liamwils20.itch.io");
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
