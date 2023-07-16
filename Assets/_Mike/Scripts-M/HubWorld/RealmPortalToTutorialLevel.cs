using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RealmPortalToTutorialLevel : MonoBehaviour
{
    private const string PLAYER = "Player";

    // If player enters trigger, load tutorial level.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER))
        {
            SceneManager.LoadScene("MainMenu"); // Change string to build index TODO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
    }
}
