using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    public GameObject player;
    public GameObject potion;
    public bool invincible;
    // Start is called before the first frame update
    void Start()
    {
        potion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Activate();
        }
    }

    void Activate()
    {

    }
}
