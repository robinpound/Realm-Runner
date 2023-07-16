using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject player;
    public GameObject canvas;
    public GameObject[] slot1;
    public GameObject[] slot2;

    public GameObject[] items;
    public int arrayPos1;
    public int arrayPos2;

    public string[] slotItem;

    public bool bow;
    public bool sword;

    public bool invincibility;
    public bool strength;
    public bool oneItem;
    public bool twoItems;

    // Start is called before the first frame update
    void Start()
    {
        arrayPos1 = 0;

    }

    // Update is called once per frame
    void Update()
    {
        sword = player.GetComponent<Sword>().swordEquipped;
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (oneItem)
            {
                slot1[arrayPos1].SetActive(true);
                slot2[0].SetActive(false);
                slot2[1].SetActive(false);
            }
            else if (twoItems)
            {
                slot1[arrayPos1].SetActive(true);
                slot2[arrayPos2].SetActive(true);
                slot1[arrayPos1 + 1].SetActive(false);
                slot2[arrayPos2 - 1].SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (oneItem)
            {
                slot1[arrayPos1].SetActive(true);
                slot2[0].SetActive(false);
                slot2[1].SetActive(false);
            }
            else if (twoItems)
            {
                slot1[arrayPos1].SetActive(false);
                slot2[arrayPos2].SetActive(false);
                slot1[arrayPos1 + 1].SetActive(true);
                slot2[arrayPos2 - 1].SetActive(true);
            }
        }
    }
    public void CurrentConsumable()
    {
        if(slot1[0] && !sword && !bow)
        {
            invincibility = true;
            //Activate Invicibility Potion
        }
        else if(slot1[1] && !sword && !bow)
        {
            strength = true;
            //Activate Invicibility Potion
        }
    }

    public void OneOrTwo()
    {
        if (!oneItem)
        {
            oneItem = true;
            if (invincibility)
            {
                arrayPos1 = 0;
            }
            else if (strength)
            {
                arrayPos1 = 1;
            }
        }
        else if (oneItem)
        {
            oneItem = false;
            twoItems = true;
        }
    }
}
