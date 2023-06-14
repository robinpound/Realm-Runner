using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDeactivate : MonoBehaviour
{
    //Vector3 previousPosition;
    //Vector3 lastMoveDirection;
    //public Rigidbody rb;
    private void Start()
    {
        //previousPosition = transform.position;
        //lastMoveDirection = Vector3.zero;
    }

    private void FixedUpdate()
    {
        //if (transform.position != previousPosition)
        //{
        //    lastMoveDirection = (transform.position - previousPosition).normalized;
        //    previousPosition = transform.position;
        //}
        //gameObject.transform.LookAt(transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Stop());
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
    }
}
