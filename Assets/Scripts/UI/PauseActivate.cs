using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseActivate : MonoBehaviour
{
    public InputActions action;
    public GameObject canvas;
    public bool paused;
    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void Pause()
    {
        if(paused == false)
        {
            paused = true;
            Debug.Log("Paused!");
            canvas.GetComponent<PauseMenu>().Pause();
        }
        else if (paused == true)
        {
            paused = false;
            Debug.Log("Un-Paused!");
            canvas.GetComponent<PauseMenu>().Resume();
            canvas.GetComponent<PauseMenu>().DeactivateAll();
        }
    }

}
