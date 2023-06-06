using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int coins;
    public int fragmentsTotal;
    public int levelFragments;
    public GameObject fragmentObjects;
    public bool[] fragmentBool = new bool[5];
    public bool[] levelComplete;
    // Start is called before the first frame update
    void Start()
    {
        fragmentObjects = GameObject.FindGameObjectWithTag("Fragments");
    }

    // Update is called once per frame
    void Update()
    {
        if(fragmentBool[0] == true && fragmentBool[1] == true && fragmentBool[2] == true && fragmentBool[3] == true && fragmentBool[4] == true) 
        {
            levelComplete[0] = true;
        }
    }
}
