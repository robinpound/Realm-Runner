using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitEvent : MonoBehaviour
{
    [SerializeField] UnityEvent playEvent;
    private const string ARROWTAG = "Arrow";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(ARROWTAG))
        {
            playEvent.Invoke();
        }
    }
}
