using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIKeyFragments : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject[] fragments;
    public int fragmentsInt;

    // Start is called before the first frame update
    void Start()
    {
        fragments[0].SetActive(false);
        fragments[1].SetActive(false);
        fragments[2].SetActive(false);
        fragments[3].SetActive(false);
        fragments[4].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            fragmentsInt += 1;
        }

        if(fragmentsInt == 1)
        {
            fragments[0].SetActive(true);
        }
        else if(fragmentsInt == 2)
        {
            fragments[1].SetActive(true);
        }
        else if(fragmentsInt == 3)
        {
            fragments[2].SetActive(true);
        }
        else if(fragmentsInt == 4)
        {
            fragments[3].SetActive(true);
        }
        else if(fragmentsInt == 5)
        {
            fragments[4].SetActive(true);
        }
    }
}
