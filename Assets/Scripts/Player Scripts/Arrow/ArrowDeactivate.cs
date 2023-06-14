using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDeactivate : MonoBehaviour
{
    Vector3 previousPosition;
    Vector3 lastMoveDirection;
    public Rigidbody rb;
    private void Start()
    {
        previousPosition = transform.position;
        lastMoveDirection = Vector3.zero;
    }

    private void FixedUpdate()
    {
        if (transform.position != previousPosition)
        {
            lastMoveDirection = (transform.position - previousPosition).normalized;
            previousPosition = transform.position;
        }
        gameObject.transform.LookAt(previousPosition);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Stop());
        //if (rb.velocity.magnitude <= 0)
        //{
        //    gameObject.SetActive(false);
        //}
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
