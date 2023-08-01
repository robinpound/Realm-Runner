using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseActivate : MonoBehaviour
{
    [Header("Don't Touch!")]
    InputActions input;
    [SerializeField] GameObject canvas;
    public bool paused;
    private void Awake()
    {
        input = new InputActions();
    }
    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    public void Update()
    {
        input.UI.Pause.started += Pause;
    }

    public void Pause(InputAction.CallbackContext context)
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
        }
    }
    private void OnEnable()
    {
        input.UI.Enable();
    }
    private void OnDisable()
    {
        input.UI.Disable();
    }
}
