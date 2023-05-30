using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseActivate : MonoBehaviour
{
    public InputActions action;
    public GameObject canvas;
    void Awake()
    {
        action = new InputActions();
        action.PlayerActions.Pause.performed += _ => Pause();
    }

    private void Pause()
    {
        Debug.Log("Woo!");
        canvas.GetComponent<PauseMenu>().Pause();
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
