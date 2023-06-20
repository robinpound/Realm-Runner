using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipped : MonoBehaviour
{
    public GameObject player;

    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            // Bow and Arrow Attack De-activation Code Goes Here.
            animator.SetBool("SwordEquipped", true);
            player.GetComponent<SwordAttack>().swordEquipped = true;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            animator.SetBool("SwordEquipped", false);
            player.GetComponent<SwordAttack>().swordEquipped = false;
            // Bow and Arrow Attack Activation Code Goes Here.
        }
    }
}
