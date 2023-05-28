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
    }
    public void Update()
    {
        if(bar.value == 0.5f || bar.value == 0.4999999f)
        {
            bar.value = 1;
        }
    }
    #region Main Menu Buttons
    public void Begin()
    {
        SceneManager.LoadScene("HubWorld");
    }
    public void LoadGame()
    {
        // Link to Load Function
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void Credits()
    {
        credits.SetActive(true);
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
    #endregion
}
