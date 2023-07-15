using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    public int maxHealth;
    public int currentHealth;
    public int attackDamage;
    public float speed;
    public bool invincible;

    [Header("Death Vars")]
    public GameObject player;
    public GameObject deathScrn;
    public Animator animator;
    public CharacterController characterController;
    public GameObject deathCam;
    public GameObject mainCam;

    // Start is called before the first frame update
    void Awake()
    {
        attackDamage = 15;
        maxHealth = 5;
        currentHealth = maxHealth;
        speed = 10;

        deathCam.SetActive(false);
        characterController = GetComponent<CharacterController>();
        characterController.enabled = true;
        animator.enabled = true;
        deathScrn.SetActive(false);
        invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //invincible = inviPotion.GetComponent<Invincibility>().invincible;

        if(currentHealth <= 0)
        {
            characterController.enabled = false;
            Invoke(nameof(DisableAnimator), 1f);
            Invoke(nameof(Die), 1.5f);
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
        deathCam.transform.position = mainCam.transform.position;
        deathCam.transform.rotation = mainCam.transform.rotation;
        deathCam.SetActive(true);
        mainCam.SetActive(false);
        deathScrn.SetActive(true);
    }
    void DisableAnimator()
    {
        animator.enabled = false;
    }
}
