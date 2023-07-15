using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTest : MonoBehaviour
{
    public GameObject player;
    public GameObject arrow;
    public GameObject turret;
    public float launchVelocity = 10f;

    public bool bow;
    // Start is called before the first frame update
    void Start()
    {
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
            }
        }
    }

    void Fire()
    {
        GameObject launch = Instantiate(arrow, transform.position, transform.rotation);
        //launch.GetComponent<Rigidbody>().AddForce(transform.forward * launchVelocity * Time.deltaTime);
        launch.transform.position = turret.transform.position;
        //launch.transform.rotation = turret.transform.rotation;
        launch.transform.eulerAngles = new Vector3(
            launch.transform.eulerAngles.x + -90,
            launch.transform.eulerAngles.y + 20,
            launch.transform.eulerAngles.z
        );

        launch.GetComponent<Rigidbody>().AddForce(transform.forward * launchVelocity, ForceMode.Impulse);
    }
}
