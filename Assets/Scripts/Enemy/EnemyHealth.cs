using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject player;

    // Enemy
    public int health;
    public GameObject enemy;
    public bool attacking;


    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        // attacking = player.GetComponent<SwordAttack>().attacking;
        if(health <= 0)
        {
            GameObject.Destroy(enemy);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(attacking && other.tag == "Sword")
        {
            int random = Random.Range(1, 5);
            health -= random;
        }
    }
}
