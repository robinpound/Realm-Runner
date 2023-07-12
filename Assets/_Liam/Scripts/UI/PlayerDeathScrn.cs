using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeathScrn : MonoBehaviour
{
    [Header("Death Scrn")]
    public GameObject confirm;
    private void Start()
    {
        confirm.SetActive(false);
    }
    public void ExitMainMenu()
    {
        confirm.SetActive(true);
    }
    #region Confirm Yes & No Functions
    public void Yes()
    {
        //Save Game Code Goes Here


        //Exit To Main Menu
        SceneManager.LoadScene("MainMenu");
    }

    public void No()
    {
        //Exit to Main Menu
        SceneManager.LoadScene("MainMenu");
    }
    #endregion

    public void LoadLastCheckpoint()
    {
        //Respawn Player back at last known checkpoint
    }

    public void ReLoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
