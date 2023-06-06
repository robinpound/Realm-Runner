using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject canvas;
    public Transform slot1;
    public Transform slot2;
    public GameObject slot1Parent;
    public GameObject slot2Parent;

    public GameObject[] items;

    private GameObject one;
    private GameObject two;
    public int arrayPos1;
    public int arrayPos2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject.Destroy(one);
            GameObject.Destroy(two);
            one = Instantiate(items[arrayPos1], slot1.transform.position, transform.rotation); ;
            one.transform.SetParent(slot1Parent.transform);

            two = Instantiate(items[arrayPos2], slot2.transform.position, transform.rotation); ;
            two.transform.SetParent(slot2Parent.transform);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject.Destroy(one);
            GameObject.Destroy(two);
            one = Instantiate(items[arrayPos2], slot1.transform.position, transform.rotation); ;
            one.transform.SetParent(slot1Parent.transform);

            two = Instantiate(items[arrayPos1], slot2.transform.position, transform.rotation); ;
            two.transform.SetParent(slot2Parent.transform);
        }
    }
}
