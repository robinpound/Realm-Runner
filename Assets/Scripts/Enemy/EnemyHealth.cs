using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyHealth : MonoBehaviour
{
    public GameObject enemy;
    public int health;
    public bool attack;

    //Input action
    public InputActions action;

    private void Awake()
    {
        //Initializing the input action system
        action = new InputActions();
        //Attack
        action.PlayerActions.Attack.started += OnPlayerAttack;
        action.PlayerActions.Attack.canceled += OnPlayerAttack;
        action.PlayerActions.Attack.performed += OnPlayerAttack;


    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            GameObject.Destroy(enemy);
        }
    }
    void OnPlayerAttack(InputAction.CallbackContext context)
    {
        attack = context.ReadValueAsButton();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sword" && attack)
        {
            int random = Random.Range(0, 10);
            health -= random;
        }
        else if (other.tag == "Arrow")
        {
            int random = Random.Range(4, 6);
            health -= random;
        }
    }

    IEnumerator Wait()
    {
        attack = true;
        yield return new WaitForSeconds(1);
        attack = false;
    }
    private void OnEnable()
    {
        action.PlayerActions.Enable();
    }
    private void OnDisable()
    {
        action.PlayerActions.Disable();
    }
}
