using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject pauseMenu;
    public GameObject player;
    public GameObject playerUI;
    public GameObject[] options;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        pauseMenu.SetActive(false);
        options[0].SetActive(false); //Main Options
        options[1].SetActive(false); //Key Bindings Page
        options[2].SetActive(false); //Audio Page
        options[3].SetActive(false); //Video Page
    }

    #region Pause Menu Buttons
    public void Pause()
    {
        pauseMenu.SetActive(true);
        playerUI.SetActive(false);
        Cursor.visible = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.GetComponent<PauseActivate>().paused = false;
        playerUI.SetActive(true);
        pauseMenu.SetActive(false);
        options[0].SetActive(false); //Main Options
        options[1].SetActive(false); //Key Bindings Page
        options[2].SetActive(false); //Audio Page
        options[3].SetActive(false); //Video Page
    }
    public void SaveGame()
    {
        //Save Game Link / Code here.
    }
    public void Options()
    {
        pauseMenu.SetActive(false);
        options[0].SetActive(true);
        options[1].SetActive(true);
    }
    public void ExitMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitDesktop()
    {
        Application.Quit();
    }
    #endregion

    #region Options Buttons
    public void OptionsBack()
    {
        pauseMenu.SetActive(true);
        options[0].SetActive(false); //Main Options
        options[1].SetActive(false); //Key Bindings Page
        options[2].SetActive(false); //Audio Page
        options[3].SetActive(false); //Video Page
    }
    public void KeyBindings()
    {
        
        options[1].SetActive(true); //Key Bindings Page
        options[2].SetActive(false); //Audio Page
        options[3].SetActive(false); //Video Page
    }
    public void Audio()
    {
        
        options[1].SetActive(false); //Key Bindings Page
        options[2].SetActive(true); //Audio Page
        options[3].SetActive(false); //Video Page
    }
    public void Video()
    {
       
        options[1].SetActive(false); //Key Bindings Page
        options[2].SetActive(false); //Audio Page
        options[3].SetActive(true); //Video Page
    }
    #endregion
}
