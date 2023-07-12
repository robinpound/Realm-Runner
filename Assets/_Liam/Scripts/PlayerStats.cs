using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    public int maxHealth;
    public int currentHealth;
    public int attackDamage;
    public float speed;
    public bool invincible;

    [Header("Death Vars")]
    public GameObject deathScrn;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.enabled = true;
        deathScrn.SetActive(false);
        invincible = false;
        attackDamage = 15;
        maxHealth = 5;
        currentHealth = maxHealth;
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //invincible = inviPotion.GetComponent<Invincibility>().invincible;

        if(currentHealth <= 0)
        {
            Die();
        }
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

    void Die()
    {
        deathScrn.SetActive(true);
        animator.enabled = false;
    }
}
