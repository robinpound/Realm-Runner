using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipped : MonoBehaviour
{
    public GameObject player;

    //Bow Objects
    public GameObject backBow;
    public GameObject handBow;
    public bool bow;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        handBow.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            BowEquip();
        }
        if (Input.GetMouseButtonUp(1))
        {
            BowDeequip();   
        }
    }
    public void BowEquip()
    {
        bow = true;
        // Swapping out GameObjects
        backBow.SetActive(false);
        handBow.SetActive(true);
    }
    public void BowDeequip()
    {
        bow = false;
        // Swapping out GameObjects
        backBow.SetActive(true);
        handBow.SetActive(false);
    }
}
