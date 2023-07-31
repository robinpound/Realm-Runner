using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyDeathDrops : MonoBehaviour
{
    [SerializeField] GameObject coins;
    [SerializeField] GameObject[] drops;
    int arrayPos;

    Vector3 pos;
    Vector3 pos1;
    Vector3 pos2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CoinLocation();
    }

    public void Drop()
    {
        int random = Random.Range(1, 10);
        var drop = Instantiate(drops[arrayPos], transform.position, transform.rotation);
        drop.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        SpawnCoins();
    }

    void CoinLocation()
    {
        Vector3 currentPos = transform.position;
        pos = new Vector3(currentPos.x * 1.2f, currentPos.y, currentPos.z);
        pos1 = new Vector3(currentPos.x, currentPos.y, currentPos.z * 1.2f);
        pos2 = new Vector3(currentPos.x * -1.2f, currentPos.y, currentPos.z);
    }

    void SpawnCoins()
    {
        // Spawning 3 different coins
        var c = Instantiate(coins, pos, transform.rotation);
        var d = Instantiate(coins, pos1, transform.rotation);
        var s = Instantiate(coins, pos2, transform.rotation);

        // Enabling the CoinCollectable ellement as it was being disabled when coins where being instantiated
        c.GetComponent<CoinCollectable>().enabled = true;
        d.GetComponent<CoinCollectable>().enabled = true;
        s.GetComponent<CoinCollectable>().enabled = true;
    }
}
