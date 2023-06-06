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
    public bool slot1Bool;
    public bool slot2Bool;
    public int arrayPos1;
    public int arrayPos2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SpawnObjects();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(arrayPos1 >= 1)
            {
                GameObject.Destroy(one);
                GameObject.Destroy(two);
                one = Instantiate(items[arrayPos1], slot1.transform.position, transform.rotation); ;
                one.transform.SetParent(slot1Parent.transform);
                one.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                slot1Bool = true;


                two = Instantiate(items[arrayPos2], slot2.transform.position, transform.rotation); ;
                two.transform.SetParent(slot2Parent.transform);
                two.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                slot2Bool = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(arrayPos2 >= 1)
            {
                GameObject.Destroy(one);
                GameObject.Destroy(two);
                two = Instantiate(items[arrayPos1], slot2.transform.position, transform.rotation); ;
                two.transform.SetParent(slot2Parent.transform);
                two.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                slot2Bool = true;

                one = Instantiate(items[arrayPos2], slot1.transform.position, transform.rotation); ;
                one.transform.SetParent(slot1Parent.transform);
                one.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                slot1Bool = true;
            }
        }
    }

    public void SpawnObjects()
    {
        if (arrayPos1 == 1)
        {
            one = Instantiate(items[arrayPos1], slot1.transform.position, transform.rotation); ;
            one.transform.SetParent(slot1Parent.transform);
            one.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            slot1Bool = true;
        }
        else if(arrayPos1 == 2)
        {
            one = Instantiate(items[arrayPos1], slot1.transform.position, transform.rotation); ;
            one.transform.SetParent(slot1Parent.transform);
            one.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            slot1Bool = true;
        }
        if(arrayPos2 == 1)
        {
            two = Instantiate(items[arrayPos2], slot2.transform.position, transform.rotation); ;
            two.transform.SetParent(slot2Parent.transform);
            two.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            slot2Bool = true;
        }
        else if (arrayPos2 == 2)
        {
            two = Instantiate(items[arrayPos2], slot2.transform.position, transform.rotation); ;
            two.transform.SetParent(slot2Parent.transform);
            two.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            slot2Bool = true;
        }
    }
}
