using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject inviPotion;
    public int health;
    public int attackDamage;
    public float speed;
    public bool invincible;
    // Start is called before the first frame update
    void Start()
    {
        invincible = false;
        attackDamage = 15;
        health = 5;
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        invincible = inviPotion.GetComponent<Invincibility>().invincible;
    }

    public void TakeDamage(int damage)
    {
        if (invincible)
        {
            invincible = false;
        }
        else if (!invincible)
        {
            health -= damage;
        }
    }
}
