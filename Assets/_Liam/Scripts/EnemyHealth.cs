using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Variables")]
    public int maxHealth = 100;
    [SerializeField] int currentHealth;
    public GameObject Deathexplosion;

    public bool isboss = false;
   
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy Died");
        //Play Death Animation
        if(Deathexplosion != null) Instantiate(Deathexplosion, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        if(isboss) { SceneManager.LoadScene("EndScene");}
    }
    public int GetCurrentHealth() {return currentHealth;}
    public void AddCurrentHealth(int health) {currentHealth += health;}
}
