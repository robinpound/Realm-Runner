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

    public bool bow;
    public int timer;

    [SerializeField] private bool isShot;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        bow = player.GetComponent<WeaponEquipped>().bow;
        if (Input.GetMouseButton(1))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Input Works!");
                Fire();
                //Invoke(nameof(Fire), 0.1f);
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
            launch.transform.eulerAngles = new Vector3(
                launch.transform.eulerAngles.x + -90,
                launch.transform.eulerAngles.y,
                launch.transform.eulerAngles.z
            ); 
            //arrow.GetComponent<ArrowNew>().IsShot();
            launch.GetComponent<Rigidbody>().AddForce(turret.transform.forward * launchVelocity, ForceMode.Impulse);
            //launch.GetComponent<Rigidbody>().velocity = turret.transform.forward * launchVelocity;
            Invoke(nameof(Reset), 1f);
        }
    }
    private void Reset()
    {
        bowArrow.SetActive(true);
        //arrow.GetComponent<ArrowNew>().IsNotShot();
        timer = 0;
    }
}
