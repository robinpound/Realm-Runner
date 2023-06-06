using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttacks : MonoBehaviour
{
    public GameObject player;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetBool("attack", true);
            Debug.Log("It Happend true");
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            animator.SetBool("attack", false);
            Debug.Log("It Happend false");
        }
    }
}
