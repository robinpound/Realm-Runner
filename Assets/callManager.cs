using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class callManager : MonoBehaviour
{
    [SerializeField] UnityEvent Set;
    [SerializeField] UnityEvent Clear;

    public void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") Set.Invoke();
    }
    public void OnTriggerExit(Collider other) {
        if(other.tag == "Player") Clear.Invoke();
    }
}
