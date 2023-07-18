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

    [SerializeField] private bool isShot;

    RigidbodyConstraints rbConstraints;
    // Cinemachine.CinemachineImpulseSource source;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.centerOfMass = transform.position;

    }
    private void Start()
    {
        //rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
    }
    private void Update()
    {
        if (isShot)
        {
            Invoke(nameof(IsNotShot), 2f);
            // Adjust the rotation of the arrow based on its velocity
            //Vector3 velocity = rigidbody.velocity;
            //float angle = Mathf.Atan(velocity.y) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.right);
        }
        
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
            else
            {
                rigidbody.isKinematic = true;
                StartCoroutine(Countdown());
            }
        }
        
    }
    public void IsShot()
    {
        isShot = true;
    }
    public void IsNotShot()
    {
        isShot = false;
    }
    IEnumerator Countdown()
    {
        IsNotShot();
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }


}
