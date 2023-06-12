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

    // Droppables
    public GameObject coin;
    public GameObject heart;
    public GameObject fragment;
    public bool spawned;

    //Damage
    public int swordDamageMin;
    public int swordDamageMax;
    public int arrowDamageMin;
    public int arrowDamageMax;


    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        swordDamageMin = 1;
        swordDamageMax = 5;
        arrowDamageMin = 4;
        arrowDamageMax = 7;
    }

    // Update is called once per frame
    void Update()
    {
        attacking = player.GetComponent<SwordAttack>().attacking;
        if(health <= 0)
        {
            Drop();
            GameObject.Destroy(enemy, 0.5f);
        }
    }
    void Drop()
    {
        int random = Random.Range(0, 100);
        if(random <= 70 && !spawned)
        {
            // Spawn Coin Where Enemy Was
            GameObject ball = Instantiate(coin, transform.position, transform.rotation);
            ball.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            spawned = true;
        }
        else if(random > 70 && random <= 90 && !spawned)
        {
            // Spawn Heart Where Enemy Was
            GameObject ball = Instantiate(heart, transform.position, transform.rotation);
            ball.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            spawned = true;
        }
        else if(random > 90 && !spawned)
        {
            // Spawn Fragment Where Enemy Was
            GameObject ball = Instantiate(fragment, transform.position, transform.rotation);
            ball.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            spawned = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sword") && attacking)
        {
            int random = Random.Range(swordDamageMin, swordDamageMax);
            health -= random;
        }
        else if (other.CompareTag("Arrow"))
        {
            int random = Random.Range(arrowDamageMin, arrowDamageMax);
            health -= random;
        }
    }
}
