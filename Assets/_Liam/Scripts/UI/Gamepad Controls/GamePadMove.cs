using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GamePadMove : MonoBehaviour
{
    [SerializeField] GameObject optionsManager;
    public RectTransform cursor;
    public GameObject curserActive;

    public Vector3 startPosition;

    //private Vector3 mousePos;
    private float mouseX, mouseY;


    [SerializeField] float speed;
    bool isMovingLeft;
    bool isMovingRight;
    bool isMovingUp;
    bool isMovingDown;
    bool reset;
    bool controller;

    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        cursor = GetComponent<RectTransform>();
        optionsManager = GameObject.FindGameObjectWithTag("OptionsManager");
        speed = optionsManager.GetComponent<OptionsManager>().GpCSlider;
        if (controller)
        {
            Mouse.current.WarpCursorPosition(new Vector2(cursor.position.x, cursor.position.y));
            Cursor.visible = false;
        }

        if (isMovingLeft)
        {
            cursor.transform.position += new Vector3(-0.1f, 0) * speed; //* Time.deltaTime;
        }
        if (isMovingRight)
        {
            cursor.transform.position += new Vector3(+0.1f, 0) * speed; //* Time.deltaTime;
        }
        if (isMovingUp)
        {
            cursor.transform.position += new Vector3(0, +0.1f) * speed; //* Time.deltaTime;
        }
        if (isMovingDown)
        {
            cursor.transform.position += new Vector3(0, -0.1f) * speed; //* Time.deltaTime;
        }
        if (reset)
        {
            transform.position = startPosition;
        }
    }
  // Function to call the Click script


    public void Click()
    {
        cursor.GetComponent<GamepadClick>().Click();
    }

    public void ActivateController()
    {
        controller = true;
        curserActive.SetActive(true);
        Cursor.visible = false;
    }
    public void DeactivateController()
    {
        controller = false;
        curserActive.SetActive(false); 
        Cursor.visible = true;
    }

    #region Moving Left
    public void OnMoveLeft()
    {
        isMovingLeft = true;
    }
    public void OnStopLeft()
    {
        isMovingLeft = false;
    }
    #endregion

    #region Moving Right
    public void OnMoveRight()
    {
        isMovingRight= true;
    }

    public void OnStopRight()
    {
        isMovingRight = false;
    }

    #endregion

    #region Moving Up
    public void OnMoveUp()
    {
        isMovingUp = true;
    }

    public void OnStopUp()
    {
        isMovingUp = false;
    }

    #endregion

    #region Moving Down
    public void OnMoveDown()
    {
        isMovingDown = true;
    }

    public void OnStopDown()
    {
        isMovingDown = false;
    }
    #endregion

    #region Reset Cursor
    public void OnMoveReset()
    {
        reset = true;
    }
    public void OnStopReset()
    {
        reset = false;
    }
    #endregion
}
