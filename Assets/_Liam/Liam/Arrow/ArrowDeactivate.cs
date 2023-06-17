using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDeactivate : MonoBehaviour
{

    private void Start()
    {

    }

    private void FixedUpdate()
    {
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
