using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeathScrn : MonoBehaviour
{
    // This entire script is for the death screen buttons
    [Header("Death Scrn")]
    [SerializeField] GameObject confirm;
    private void Start()
    {
        // Turning off the confirm pop-up
        confirm.SetActive(false);
    }
    // Function to activate the Pop-Up to confirm if the player actually wants to leave
    public void ExitMainMenu()
    {
        confirm.SetActive(true);
    }
    // Region for confirm pop-up yes and no buttons 
    #region Confirm Yes & No Functions
    public void Yes()
    {
        //Save Game Code Goes Here


        //Exit To Main Menu
        SceneManager.LoadScene("MainMenu");
    }

    public void No()
    {
        //Close the Confirmation Pop-Up
        confirm.SetActive(false);
        
    }
    #endregion

    // Function for the Player to respawn.
    // Currently Just resets the scene, however in the future change to transport the player back to their last checkpoint.
    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
