using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    CharacterController controller;
    MovementController movement;

    private void Awake() {
        controller = GetComponent<CharacterController>();
        movement = FindObjectOfType<MovementController>();
    }
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    public void PlayerGravity(){

    }
}
