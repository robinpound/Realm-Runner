using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class UiInput : MonoBehaviour
{
    private InputActions input;
    [Header("Cursor - Manually Assign")]
    [SerializeField] GameObject c;
    [Header("Don't Touch")]
    [SerializeField] GamePadMove g;
    [SerializeField] GameObject player;
    bool move;
    public bool scrollUp;
    public bool scrollDown;
    private void Awake()
    {
        input = new InputActions();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Getting GamePadMove script for Function calling
        g = c.GetComponent<GamePadMove>();

        #region Gamepad Cursor Move

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

        input.UI.Reset.started += OnMoveReset;
        input.UI.Reset.performed += OnMoveReset;
        input.UI.Reset.canceled += OnStopReset;

        #endregion

        #region Cursor Activate
        input.UI.Controller.started += ActivateController;
        input.UI.Controller.performed += ActivateController;
        input.UI.Controller.canceled += ActivateController;

        input.UI.Keyboard.started += DeactivateController;
        input.UI.Keyboard.performed += DeactivateController;
        input.UI.Keyboard.canceled += DeactivateController;

        #endregion

        #region Cursor Click
        input.UI.Click.started += Click;
        #endregion

        input.UI.ScrollDown.started += ScrollDown;
        input.UI.ScrollDown.performed += ScrollDown;
        input.UI.ScrollDown.canceled += ScrollDown;

        input.UI.ScrollUp.started += ScrollUp;
        input.UI.ScrollUp.performed += ScrollUp;
        input.UI.ScrollUp.canceled += ScrollUp;

    }
    void ScrollDown(InputAction.CallbackContext context)
    {
        scrollDown = context.ReadValueAsButton();
    }
    void ScrollUp(InputAction.CallbackContext context)
    {
        scrollUp= context.ReadValueAsButton();
    }
    // Function for Calling the click Script
    void Click(InputAction.CallbackContext context)
    {
        g.Click();
    }

    #region Activate Cursor
    void ActivateController(InputAction.CallbackContext context)
    {
        g.ActivateController();
    }
    void DeactivateController(InputAction.CallbackContext context)
    {
        g.DeactivateController();
    }
    #endregion

    #region Moving Left
    void OnMoveLeft(InputAction.CallbackContext context)
    {
        g.OnMoveLeft();
    }
    void OnStopLeft(InputAction.CallbackContext context)
    {
        g.OnStopLeft();
    }
    #endregion

    #region Moving Right
    void OnMoveRight(InputAction.CallbackContext context)
    {
        g.OnMoveRight();
    }

    void OnStopRight(InputAction.CallbackContext context)
    {
        g.OnStopRight();
    }

    #endregion

    #region Moving Up
    void OnMoveUp(InputAction.CallbackContext context)
    {
        g.OnMoveUp();
    }

    void OnStopUp(InputAction.CallbackContext context)
    {
        g.OnStopUp();
    }

    #endregion

    #region Moving Down
    void OnMoveDown(InputAction.CallbackContext context)
    {
        g.OnMoveDown();
    }

    void OnStopDown(InputAction.CallbackContext context)
    {
        g.OnStopDown();
    }
    #endregion

    #region Reset Cursor
    public void OnMoveReset(InputAction.CallbackContext context)
    {
        g.OnMoveReset();
    }
    public void OnStopReset(InputAction.CallbackContext context)
    {
        g.OnStopReset();
    }
    #endregion

    private void OnEnable()
    {
        input.UI.Enable();
    }
    private void OnDisable()
    {
        input.UI.Disable();
    }
}
