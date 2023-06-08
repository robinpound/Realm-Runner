using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public GameObject arrow;
    public int launchVelocity;
    public int arrowOn;
    public bool reloading;

    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if(arrowOn == 1 && !reloading)
            {
                arrowOn = arrowOn - 1;
                Fire();
            }
        }
        if (arrowOn <= 0)
        {
            StartCoroutine(Reload());
        }
        if (reloading)
        {
            animator.SetBool("reload", true);
        }
        else if (!reloading)
        {
            animator.SetBool("reload", false);
        }
    }

    public void Fire()
    {
        GameObject ball = Instantiate(arrow, transform.position, transform.rotation);
        ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, launchVelocity));
    }
    IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(1);
        if (arrowOn <= 0)
        {
            arrowOn = 1;
        }
        reloading = false;
        StopCoroutine(Reload());
    }
}
