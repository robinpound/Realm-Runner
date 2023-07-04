using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowNew : MonoBehaviour
{
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
        if (collision.gameObject.name != "Player")
        {
            rigidbody.isKinematic = true;
            StartCoroutine(Countdown());
        }
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }


}
