using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadCursor : MonoBehaviour
{
    public GameObject cursor;
    public GameObject canvas;
    bool connected;

    // Start is called before the first frame update
    void Start()
    {
        cursor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        connected = canvas.GetComponent<ControllerCheck>().connected;
        if (connected)
        {
            cursor.SetActive(true);
        }
        else if (!connected)
        {
            cursor.SetActive(false);
        }
    }
}
