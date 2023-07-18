using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ArrowTest : MonoBehaviour
{
    public GameObject player;
    public GameObject arrow;
    public GameObject turret;
    [SerializeField] GameObject bowArrow;
    public float launchVelocity = 10f;

    public int timer;
    [SerializeField] bool isShot;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        bowArrow = GameObject.Find("Arrow");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Input Works!");
                Fire();
            }
        }
    }

    void Fire()
    {
        if(timer >= 0)
        {
            timer = 1;
            bowArrow.SetActive(false);
            GameObject launch = Instantiate(arrow, transform.position, transform.rotation);
            launch.transform.position = turret.transform.position;
            launch.transform.rotation = turret.transform.rotation;
            //launch.transform.eulerAngles = new Vector3(
            //    launch.transform.eulerAngles.x + -80,
            //    launch.transform.eulerAngles.y + 20,
            //    launch.transform.eulerAngles.z
            //);
            launch.GetComponent<ArrowNew>().IsShot();
            launch.GetComponent<Rigidbody>().AddForce(transform.forward * launchVelocity, ForceMode.Impulse);
            Invoke(nameof(Reset), 1f);
        }
    }
    private void Reset()
    {
        bowArrow.SetActive(true);
        timer = 0;
    }
}
