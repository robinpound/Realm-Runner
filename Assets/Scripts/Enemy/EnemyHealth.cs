using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject enemy;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            GameObject.Destroy(enemy);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sword")
        {
            int random = Random.Range(0, 10);
            health -= random;
        }
        else if (other.tag == "Arrow")
        {
            int random = Random.Range(4, 6);
            health -= random;
        }
    }
}
