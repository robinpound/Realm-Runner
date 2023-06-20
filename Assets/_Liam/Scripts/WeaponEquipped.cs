using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipped : MonoBehaviour
{
    public GameObject player;

    public Animator animator;

    //Sword Objects
    public GameObject backSword;
    public GameObject handSword;

    //Bow Objects
    public GameObject backBow;
    public GameObject handBow;

    private void Start()
    {
        animator = GetComponent<Animator>();

        handBow.SetActive(false);
        backBow.SetActive(true);
        backSword.SetActive(true);
        handSword.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            // Bow and Arrow Attack De-activation Code Goes Here.
            animator.SetBool("SwordEquipped", true);
            player.GetComponent<SwordAttack>().swordEquipped = true;
            StartCoroutine(SwordEquipper());
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            animator.SetBool("SwordEquipped", false);
            player.GetComponent<SwordAttack>().swordEquipped = false;
            StartCoroutine(BowEquipper());
            // Bow and Arrow Attack Activation Code Goes Here.
        }
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
}
