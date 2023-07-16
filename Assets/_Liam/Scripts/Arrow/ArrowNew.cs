using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Created by Liam.
// On Collision method altered by Michael to call take damage method on enemies.

public class ArrowNew : MonoBehaviour
{
    [Header("Arrow Settings")]
    [SerializeField]
    private int damage = 50;
    [Header("Debugs")]
    public Rigidbody rigidbody;
   // Cinemachine.CinemachineImpulseSource source;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = transform.position;
    }
    private void Update()
    {
        //transform.LookAt(look.transform.position);
        
    }
    public void OnCollisionEnter(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

        if (collision != null)
        {
            if (enemyHealth != null)
            {
                Debug.Log(collision.gameObject.name + " was hit with an arrow to the knee");
                enemyHealth.TakeDamage(damage);
                StartCoroutine(Countdown());
            }
            else return;
            rigidbody.isKinematic = true;
            StartCoroutine(Countdown());
        }
        
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }


}
