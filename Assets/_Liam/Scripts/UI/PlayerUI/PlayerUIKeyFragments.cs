using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIKeyFragments : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject[] fragments;
    public int fragmentsInt;
    public int arrayPos;

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
            AddFragment();
        }

    }

    public void AddFragment()
    {
        arrayPos += 1;
        fragments[arrayPos].SetActive(true);
    }
}
