using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIHealth : MonoBehaviour
{
    [SerializeField] GameObject player;
    float health;
    [SerializeField] GameObject[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        // Assigning Player GameObject to player variable
        player = GameObject.FindGameObjectWithTag("Player");
        // Assigning UI Hearts to the hearts array variable
        hearts = GameObject.FindGameObjectsWithTag("Heart");
    }

    // Update is called once per frame
    void Update()
    {
        // Getting the currentHealth from the PlayerStats script
        health = player.GetComponent<PlayerStats>().currentHealth;

        // This Region ha if Statements which determins the health of the player and reflects that by removing or adding hearts.
        #region Main Hearts
        if (health <= 5 && health > 4)
        {
            hearts[4].SetActive(true);
            hearts[3].SetActive(true);
            hearts[2].SetActive(true);
            hearts[1].SetActive(true);
            hearts[0].SetActive(true);
        }
        else if (health <= 4 && health > 3)
        {
            hearts[0].SetActive(false);
        }
        else if (health <= 3 && health > 2)
        {
            hearts[1].SetActive(false);
        }
        else if (health <= 2 && health > 1)
        {
            hearts[2].SetActive(false);
        }
        else if (health <= 1 && health > 0)
        {
            hearts[3].SetActive(false);
        }
        else if (health <= 0)
        {
            hearts[4].SetActive(false);
        }
        #endregion

    }
}
