using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Code from Liam!!

public class Tutorial : MonoBehaviour
{
    [Header("Test Variables")]
    [SerializeField] GameObject p;
    [SerializeField] TMP_Text prompt;
    [SerializeField] string text;

    [SerializeField] GameObject gamepad;
    [SerializeField] GamePadMove g;

    [Header("Bools")]
    [SerializeField] bool controller;
    [SerializeField] bool tutorialComplete;
    [SerializeField] bool move;
    [SerializeField] bool jump;
    [SerializeField] bool look;
    [SerializeField] bool aim;
    [SerializeField] bool shoot;
    private void Start()
    {
        //NEED TO RE-ENABLE THESE BEFORE FINAL BUILD!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        

        //gamepad = GameObject.Find("Gamepad Cursor");
        //g = gamepad.GetComponent<GamePadMove>();
    }

    // Update is called once per frame
    void Update()
    {
        controller = g.controller;
    }
    #region Tutorial Functions
    public void Move()
    {
        if (!tutorialComplete)
        {
            if (!controller)
            {
                if (!move)
                {
                    text = "Use W, A, S, D to Move";
                    prompt.text = text;
                }
            }
            else if (controller)
            {
                if (!move)
                {
                    text = "Use LEFT STICK to move";
                    prompt.text = text;
                }
            }
        }
    }
    public void Jump()
    {
        if (!tutorialComplete)
        {
            if (!controller)
            {
                if (move && !jump)
                {
                    text = "Use SPACE to Jump";
                    prompt.text = text;
                }
            }
            else if (controller)
            {
                if (move && !jump)
                {
                    text = "Use A/X to Jump";
                    prompt.text = text;
                }
            }
        }
    }
    public void Look() 
    {
        if (!tutorialComplete)
        {
            if (!controller)
            {
                if (move && jump && !look)
                {
                    text = "Use MOUSE to pan the camera";
                    prompt.text = text;
                }
            }
            else if (controller)
            {
                if (move && jump && !look)
                {
                    text = "Use RIGHT STICK to pan the camera";
                    prompt.text = text;
                }
            }
        }
    }
    public void Aim()
    {
        if (!tutorialComplete)
        {
            if (!controller)
            {
                if (move && jump && look && !aim)
                {
                    text = "Hold RIGHT MOUSE BUTTON to aim";
                    prompt.text = text;
                }
            }
            else if (controller)
            {
                if (move && jump && look && !aim)
                {
                    text = "Hold LEFT TRIGGER to aim";
                    prompt.text = text;
                }
            }
        }
    }
    public void Shoot()
    {
        if (!tutorialComplete)
        {
            if (!controller)
            {
                if (move && jump && look && aim && !shoot)
                {
                    text = "While Aiming, press LEFT MOUSE BUTTON to shoot";
                    prompt.text = text;
                }
            }
            else if (controller)
            {
                if (move && jump && look && aim && !shoot)
                {
                    text = "While Aiming   press RIGHT TRIGGER to shoot";
                    prompt.text = text;
                }
            }
        }
    }
    public void Other(string text)
    {
        prompt.text = text;
    }
    public void TutorialComplete()
    {
        tutorialComplete = true;

        // End Tutorial Level Code to go here!!!
    }
    #endregion
}
