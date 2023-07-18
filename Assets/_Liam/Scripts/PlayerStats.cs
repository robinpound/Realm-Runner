using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]
    public int maxHealth;
    public int currentHealth;
    public bool invincible;

    [Header("Don't Touch!")]
    [Header("Death Vars")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject deathScrn;
    [SerializeField] Animator animator;
    [SerializeField] CharacterController characterController;
    [SerializeField] GameObject deathCam;
    [SerializeField] GameObject mainCam;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        deathScrn = GameObject.FindGameObjectWithTag("DeathScreen");
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Start()
    {
        maxHealth = 5;
        currentHealth = maxHealth;
        // Activating or Deactivating GameObjects or components
        deathCam.SetActive(false);
        characterController.enabled = true;
        animator.enabled = true;
        deathScrn.SetActive(false);
        invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //invincible = inviPotion.GetComponent<Invincibility>().invincible;
        // Determining if the Player has run out of health, if so run death functions
        if(currentHealth <= 0)
        {
            characterController.enabled = false;
            Invoke(nameof(DisableAnimator), 1f);
            Invoke(nameof(Die), 1.5f);
        }
    }

    public void TakeDamage(int damage)
    {
        //Player TakeDamage function which determins if the player has invincibility
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
        // Unlocking cursor and making it visible
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //Setting the Death Camera to the Main Camera Position, which also locks it so it cannot rotate with mouse anymore.
        deathCam.transform.position = mainCam.transform.position;
        deathCam.transform.rotation = mainCam.transform.rotation;
        // Activating Death Cam and Deactivating Main Cam, aswell as Death Screen
        deathCam.SetActive(true);
        mainCam.SetActive(false);
        deathScrn.SetActive(true);
    }
    // Function to disable animator. Used for Ragdoll death effect
    void DisableAnimator()
    {
        animator.enabled = false;
    }
    public void InstaDead()
    {
        // This function insta kills the player for if they fall in the water
        currentHealth = 0;
    }
    // Function to add health for health collectable.
    public void AddHealth(int health)
    {
        currentHealth += health;
    }
}
