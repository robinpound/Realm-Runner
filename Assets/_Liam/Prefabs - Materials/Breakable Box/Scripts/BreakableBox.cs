using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBox : MonoBehaviour
{
    //GameObjects
    public GameObject box;
    public GameObject boxParticle;
    public GameObject[] itemDrop;

    //Item Drop Array Min and Max
    public int arrayPos;
    public int minArray;
    public int maxArray;

    //Box Vars
    public int health;
    //Damage Ints
    public int minDamage;
    public int maxDamage;

    //Box Break Effects
    public GameObject effect;

    private bool isCreated;

    //Spawn Amount
    private int amount = 20;

    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        minDamage = 1;
        maxDamage = 5;

        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            if (!isCreated)
            {
                GameObject puff = Instantiate(effect);
                isCreated = true;
                Destroyed();
            }
            GameObject.Destroy(box);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            health = 0;
        }
    }

    void Destroyed()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject ball = Instantiate(boxParticle);
            ball.transform.position = position;
            Destroy(ball, 3.0f);
        }

        Spawn();
    }

    void Spawn()
    {
        int random = Random.Range(minArray, maxArray);
        arrayPos = random;
        GameObject clone = Instantiate(itemDrop[arrayPos]);
        clone.transform.position = position;
    }

}
