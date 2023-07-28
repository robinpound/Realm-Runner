using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CallSlidingDoor : MonoBehaviour
{
    [SerializeField] private UnityEvent openDoor;
    private InteractAreaTriggerBookKey interactArea;
    

    private void Start()
    {
        interactArea = GetComponent<InteractAreaTriggerBookKey>();
    }

    private void FixedUpdate()
    {
        if (interactArea != null && interactArea.bookKeyTrigger
            && Input.GetKey(KeyCode.E))
        {
            openDoor.Invoke();
        }
    }
}
