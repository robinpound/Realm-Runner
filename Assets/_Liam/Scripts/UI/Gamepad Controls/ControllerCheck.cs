using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerCheck : MonoBehaviour
{
    public bool connected = false;

    IEnumerator CheckForControllers()
    {
        while (true)
        {
            var controllers = Input.GetJoystickNames();

            if (!connected && controllers.Length > 1)
            {
                connected = true;
                Debug.Log("Connected");

            }
            else if (connected && controllers.Length == 0)
            {
                connected = false;
                Debug.Log("Disconnected");
            }

            yield return new WaitForSeconds(1f);
        }
    }

    void Awake()
    {
        StartCoroutine(CheckForControllers());
    }
}
