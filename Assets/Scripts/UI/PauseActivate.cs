using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseActivate : MonoBehaviour
{
    public InputActions action;
    public GameObject canvas;
    public bool paused;
    void Awake()
    {
        action = new InputActions();
        action.PlayerActions.Pause.performed += _ => Pause();
    }
    private void Start()
    {
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

    private void OnEnable()
    {
        action.Enable();
    }
    private void OnDisable()
    {
        action.Disable();
    }

}
