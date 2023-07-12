using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIHealth : MonoBehaviour
{
    public GameObject player;
    public float health;
    public float damage = 0.5f;
    public GameObject[] hearts;

    // Update is called once per frame
    void Update()
    {
        health = player.GetComponent<PlayerStats>().currentHealth;
        if (Input.GetKeyDown(KeyCode.F))
        {
            health -= damage;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            health = 5;
        }

        #region Main Hearts
        else if (health <= 5 && health > 4)
        {
            hearts[4].SetActive(true);
            hearts[3].SetActive(true);
            hearts[2].SetActive(true);
            hearts[1].SetActive(true);
            hearts[0].SetActive(true);
        }
        else if (health <= 4 && health > 3)
        {
            hearts[4].SetActive(false);
        }
        else if (health <= 3 && health > 2)
        {
            hearts[3].SetActive(false);
        }
        else if (health <= 2 && health > 1)
        {
            hearts[2].SetActive(false);
        }
        else if (health <= 1 && health > 0)
        {
            hearts[1].SetActive(false);
        }
        else if (health <= 0)
        {
            hearts[0].SetActive(false);
            GameObject.Destroy(player);
        }
        #endregion

    }
}
