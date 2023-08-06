using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CallPortalDoorEvent : MonoBehaviour
{
    [SerializeField] UnityEvent doorEvent;
    private const string PLAYER = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER))
        {
            doorEvent.Invoke();
        }
    }
}
