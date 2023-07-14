#define USE_NEW_INPUT_SYSTEM
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Lolopupka
{
public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private PlayerIputActions playerIputActions;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one InputManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        playerIputActions = new PlayerIputActions();
        playerIputActions.Player.Enable();
    }

    public Vector2 GetMouseScreenPostion()
    {
#if USE_NEW_INPUT_SYSTEM
        return Mouse.current.position.ReadValue();
#else
        return Input.mousePosition;
#endif
    }

    public bool IsMouseButtonDownThisFrame()
    {

#if USE_NEW_INPUT_SYSTEM
        return playerIputActions.Player.Click.WasPressedThisFrame();
#else
        return Input.GetMouseButton(0);
#endif
    }

    public Vector2 GetCameraMoveVector()
    {
#if USE_NEW_INPUT_SYSTEM
        return playerIputActions.Player.CameraMovment.ReadValue<Vector2>();
#else
        Vector2 InputMoveDir = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            InputMoveDir.y = +1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            InputMoveDir.x = -1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            InputMoveDir.y = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            InputMoveDir.x = +1f;
        }

        return InputMoveDir;
#endif
    }

    public float GetCameraRotateAmount()
    {
#if USE_NEW_INPUT_SYSTEM
        return playerIputActions.Player.CameraRotate.ReadValue<float>();
#else
        float rotateAmount = 0f;

        if(Input.GetKey(KeyCode.Q))
        {
            rotateAmount = +1f;
        }

        if(Input.GetKey(KeyCode.E))
        {
            rotateAmount = -1f;
        }

        return rotateAmount;
#endif
    }

    public float GetCameraZoomAmount()
    {
#if USE_NEW_INPUT_SYSTEM
        return playerIputActions.Player.CameraZoom.ReadValue<float>();
#else
        float zoomAmount = 0f;

        if (Input.mouseScrollDelta.y > 0)
        {
            zoomAmount = -1f;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            zoomAmount = +1f;
        }

        return zoomAmount;
#endif
    }
}
}
