using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
public class GamePadMove : MonoBehaviour
{
    public InputActions input;
    public RectTransform cursor;
    public GameObject curserActive;

    public Vector3 startPosition;

    public int speed = 10;
    public bool isMovingLeft;
    public bool isMovingRight;
    public bool isMovingUp;
    public bool isMovingDown;
    public bool reset;
    public bool click;
    private void Awake()
    {
        input = new InputActions();
    }

    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        input.UI.LSLeft.started += OnMoveLeft;
        input.UI.LSLeft.performed += OnMoveLeft;
        input.UI.LSLeft.canceled += OnStopLeft;

        input.UI.LSRight.started += OnMoveRight;
        input.UI.LSRight.performed += OnMoveRight;
        input.UI.LSRight.canceled += OnStopRight;

        input.UI.LSUp.started += OnMoveUp;
        input.UI.LSUp.performed += OnMoveUp;
        input.UI.LSUp.canceled += OnStopUp;

        input.UI.LSDown.started += OnMoveDown;
        input.UI.LSDown.performed += OnMoveDown;
        input.UI.LSDown.canceled += OnStopDown;

        input.UI.Click.started += OnClick;
        input.UI.Click.performed += OnClick;
        input.UI.Click.canceled += OnClickStop;

        input.UI.Reset.started += OnMoveReset;
        input.UI.Reset.performed += OnMoveReset;
        input.UI.Reset.canceled += OnStopReset;



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
        if (click)
        {
            //Debug.Log("Clicked");
            
        }
    }


    #region Moving Left
    void OnMoveLeft(InputAction.CallbackContext context)
    {
        isMovingLeft = true;
    }
    void OnStopLeft(InputAction.CallbackContext context)
    {
        isMovingLeft = false;
    }
    #endregion

    #region Moving Right
    void OnMoveRight(InputAction.CallbackContext context)
    {
        isMovingRight= true;
    }

    void OnStopRight(InputAction.CallbackContext context)
    {
        isMovingRight = false;
    }

    #endregion

    #region Moving Up
    void OnMoveUp(InputAction.CallbackContext context)
    {
        isMovingUp= true;
    }

    void OnStopUp(InputAction.CallbackContext context)
    {
        isMovingUp= false;
    }

    #endregion

    #region Moving Down
    void OnMoveDown(InputAction.CallbackContext context)
    {
        isMovingDown = true;
    }

    void OnStopDown(InputAction.CallbackContext context)
    {
        isMovingDown = false;
    }
    #endregion

    #region Cursor Clicks
    public void OnClick(InputAction.CallbackContext context)
    {
        click = true;
    }
    public void OnClickStop(InputAction.CallbackContext context)
    {
        click = false;
    }
    #endregion

    #region Reset Cursor
    public void OnMoveReset(InputAction.CallbackContext context)
    {
        reset = true;
    }
    public void OnStopReset(InputAction.CallbackContext context)
    {
        reset = false;
    }
    #endregion

    private void OnEnable()
    {
        input.UI.LSLeft.Enable();
        input.UI.LSRight.Enable();
        input.UI.LSUp.Enable();
        input.UI.LSDown.Enable();
        input.UI.Reset.Enable();
        input.UI.Click.Enable();
    }
    private void OnDisable()
    {
        input.UI.LSLeft.Disable();
        input.UI.LSRight.Disable();
        input.UI.LSUp.Disable();
        input.UI.LSDown.Disable();
        input.UI.Reset.Disable();
        input.UI.Click.Disable();
    }
}
