using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class PlayerStats : MonoBehaviour
{
    public Animator animator;

    public GameObject inviPotion;
    public int maxHealth;
    public int currentHealth;
    public int attackDamage;
    public float speed;
    public bool invincible;
    public bool dead;

    public float timeLeft = 5; 
    public float countDown = 5;

    public GameObject deadDisply;
    public Text countDownDisplay;

    public GameObject cam1;
    public GameObject cam2;

    public GameObject playerUI;
    // Start is called before the first frame update
    void Start()
    {
        cam1.SetActive(true);
        cam2.SetActive(false);
        animator.enabled = true;
        deadDisply.SetActive(false);
        invincible = false;
        attackDamage = 15;
        maxHealth = 5;
        currentHealth = maxHealth;
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        invincible = inviPotion.GetComponent<Invincibility>().invincible;
        if(currentHealth <= 0)
        {
            Die();
        }
        countDownDisplay.text = countDown.ToString();
    }

    public void TakeDamage(int damage)
    {
        if (invincible)
        {
            invincible = false;
        }
        else if (!invincible)
        {
            currentHealth -= damage;
        }
    }
    //Function to call and run death animations + destroy player
    void Die()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
        playerUI.SetActive(false);
        deadDisply.SetActive(true);

        animator.enabled = false;
        //Player Death Animations Here

        //Reload Scene
        Invoke(nameof(ResetScene), 5);
    }
    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
