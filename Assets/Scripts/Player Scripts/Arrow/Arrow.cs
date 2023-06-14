using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    //Object Pooling Vars
    public static Arrow SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    public GameObject turret;

    //bullet Vars
    public int launchVelocity;
    public bool ammo;

    public GameObject[] powerIndicator;

    public ArrowSlider slider;

    private void Awake()
    {
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            launchVelocity++;
            slider.SetPower(launchVelocity);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
            launchVelocity = 0;
            slider.SetPower(launchVelocity);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            launchVelocity = 0;
            slider.SetPower(launchVelocity);
        }
        if(launchVelocity == 0)
        {
            powerIndicator[0].SetActive(false);
            powerIndicator[2].SetActive(false);
            powerIndicator[1].SetActive(false);
        }
        else if(launchVelocity <= 200 && launchVelocity > 0)
        {
            powerIndicator[0].SetActive(true);
            powerIndicator[2].SetActive(false);
            powerIndicator[1].SetActive(false);
        }
        else if(launchVelocity >= 201 && launchVelocity <= 500)
        {
            powerIndicator[1].SetActive(true);
            powerIndicator[0].SetActive(false);
            powerIndicator[2].SetActive(false);
        }
        else if (launchVelocity >= 501)
        {
            powerIndicator[2].SetActive(true);
            powerIndicator[0].SetActive(false);
            powerIndicator[1].SetActive(false);
        }
    }
    public void Fire()
    {
        GameObject bullet = Arrow.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = turret.transform.position;
            bullet.transform.rotation = turret.transform.rotation;
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, launchVelocity));
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
