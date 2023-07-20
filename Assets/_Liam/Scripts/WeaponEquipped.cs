using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipped : MonoBehaviour
{
    [SerializeField] GameObject player;

    //Bow Objects
    [SerializeField] GameObject backBow;
    [SerializeField] GameObject handBow;
    public bool bow;

    private void Awake()
    {
        // Fetching player character
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        // Setting bow inactive
        handBow.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        // Activate bow on aim
        if (Input.GetMouseButtonDown(1))
        {
            BowEquip();
        }
        // Deactivate bow on !aim
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
