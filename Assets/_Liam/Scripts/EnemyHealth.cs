using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject player;

    public int health;
    public bool attacking;

    public int minSwordDamage;
    public int maxSwordDamage;
    // Start is called before the first frame update
    void Start()
    {
        health = 5;

        minSwordDamage = 0;
        maxSwordDamage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        attacking = player.GetComponent<SwordAttack>().attacking;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sword")
        {
            int random = Random.Range(minSwordDamage, maxSwordDamage);
            health -= random;
        }
    }
}
