using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
            launchVelocity = 0;
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
