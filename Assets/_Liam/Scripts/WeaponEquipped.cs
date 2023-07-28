using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponEquipped : MonoBehaviour
{
    InputActions input;
    [SerializeField] GameObject player;

    //Bow Objects
    [SerializeField] GameObject backBow;
    [SerializeField] GameObject handBow;
    public bool bow;

    [SerializeField] bool aiming;

    private void Awake()
    {
        input = new InputActions();
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

        input.PlayerActions.ArrowAiming.started += Bool;
        input.PlayerActions.ArrowAiming.performed += Bool;
        input.PlayerActions.ArrowAiming.canceled += Bool;


        // Activate bow on aim
        if (aiming)
        {
            BowEquip();
        }
        // Deactivate bow on !aim
        if (!aiming)
        {
            BowDeequip();   
        }
    }
    private void Bool(InputAction.CallbackContext context)
    {
        aiming = context.ReadValueAsButton();
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

    private void OnEnable()
    {
        input.PlayerActions.Enable();
    }
    private void OnDisable()
    {
        input.PlayerActions.Disable();
    }
}
