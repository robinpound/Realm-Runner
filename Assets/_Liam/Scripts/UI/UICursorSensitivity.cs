using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.InputSystem.Processors;

public class UICursorSensitivity : MonoBehaviour
{
    public InputActionAsset inputActionAsset;
    public InputAction Look;
    ScaleVector2Processor scaleVectorX;
    // Start is called before the first frame update
    void Start()
    {
        inputActionAsset = GameObject.Find("EventSystem").GetComponent<InputSystemUIInputModule>().actionsAsset;
        Look = inputActionAsset.FindActionMap("PlayerActions").FindAction("Look");
        Debug.Log(Look.processors);// returns ScaleVector2
    }

    // Update is called once per frame
    void Update()
    {
        Look.ApplyBindingOverride(new InputBinding
        {
            overrideProcessors = "scaleVector2(x=1.2, y=1.3)"
        });
    }
}
