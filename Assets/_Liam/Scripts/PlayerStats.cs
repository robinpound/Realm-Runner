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

    public void InstaDead()
    {
        currentHealth = 0;
    }

    void Die()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
