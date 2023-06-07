using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIHealth : MonoBehaviour
{
    public GameObject player;
    public float health;
    public GameObject[] hearts;
    public GameObject[] extra;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        extra[4].SetActive(false);
        extra[3].SetActive(false);
        extra[2].SetActive(false);
        extra[1].SetActive(false);
        extra[0].SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            health -= 0.5f;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            health = 5;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            health = 10;
            StartCoroutine(Wait());
        }

        #region Extra Hearts
        else if (health <= 10 && health > 9)
        {
            hearts[4].SetActive(true);
            hearts[3].SetActive(true);
            hearts[2].SetActive(true);
            hearts[1].SetActive(true);
            hearts[0].SetActive(true);
            extra[4].SetActive(true);
            extra[3].SetActive(true);
            extra[2].SetActive(true);
            extra[1].SetActive(true);
            extra[0].SetActive(true);

        }
        else if (health <= 10 && health > 9)
        {
            extra[4].SetActive(false);
        }
        else if (health <= 9 && health > 8)
        {
            extra[3].SetActive(false);
        }
        else if (health <= 8 && health > 7)
        {
            extra[2].SetActive(false);
        }
        else if (health <= 7 && health > 6)
        {
            extra[1].SetActive(false);
        }
        else if (health <= 6 && health > 5)
        {
            extra[0].SetActive(false);
        }
        #endregion
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
    IEnumerator Wait()
    {
        extra[4].SetActive(true);
        extra[3].SetActive(true);
        extra[2].SetActive(true);
        extra[1].SetActive(true);
        extra[0].SetActive(true);
        yield return new WaitForSeconds(60);
        extra[4].SetActive(false);
        extra[3].SetActive(false);
        extra[2].SetActive(false);
        extra[1].SetActive(false);
        extra[0].SetActive(false);
        if(health <= 5)
        {

        }
        else if (health >= 5)
        {
            health = 5;
        }
    }
}
