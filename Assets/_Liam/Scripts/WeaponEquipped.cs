using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponEquipped : MonoBehaviour
{
    public InputActions action;
    public GameObject player;

    public Animator animator;

    //Sword Objects
    public GameObject backSword;
    public GameObject handSword;

    //Bow Objects
    public GameObject backBow;
    public GameObject handBow;
    public bool bow;

    private void Awake()
    {
        action = new InputActions();
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        handBow.SetActive(false);
        handSword.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        //action.PlayerActions.SwordSwap.started += SwordEquip;
        //action.PlayerActions.BowSwap.started += BowEquip;

        if (Input.GetKey(KeyCode.Alpha1))
        {
            SwordEquip();
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            BowEquip();
        }
    }

    public void SwordEquip()//(InputAction.CallbackContext context)
    {
        // Bow and Arrow Attack De-activation Code Goes Here.
        animator.SetBool("SwordEquipped", true);
        player.GetComponent<Sword>().swordEquipped = true;
        bow = false;
        StartCoroutine(SwordEquipper());
    }

    public void BowEquip()//(InputAction.CallbackContext context)
    {
        animator.SetBool("SwordEquipped", false);
        player.GetComponent<Sword>().swordEquipped = false;
        bow = true;
        StartCoroutine(BowEquipper());
        // Bow and Arrow Attack Activation Code Goes Here.
    }

    public void ConsumableEquipper()
    {

    }

    IEnumerator SwordEquipper()
    {
        yield return new WaitForSeconds(0.2f);
        backBow.SetActive(true);
        handBow.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        backSword.SetActive(false);
        handSword.SetActive(true);
    }

    IEnumerator BowEquipper()
    {
        yield return new WaitForSeconds(0.2f);
        backSword.SetActive(true);
        handSword.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        backBow.SetActive(false);
        handBow.SetActive(true);
    }

    private void OnEnable()
    {
        action.PlayerActions.Enable();
    }

    private void OnDisable()
    {
        action.PlayerActions.Disable();
    }
}
