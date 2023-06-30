using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public Transform player;
    public GameObject arrow;
    //Object Pooling Vars
    [Header("Object Pooling GameObjects")]
    [Tooltip("Object To Pool is the gameobject you wish to spawn")]
    public GameObject objectToPool;
    [Tooltip("Turret is the object in which the pooled objects will fly from")]
    public GameObject turret;
    [Tooltip("A list of pooled gameobjects for launching")]
    public List<GameObject> pooledObjects;
    [Header("Amount to Pool")]
    public static Arrow SharedInstance;
    [Tooltip("Amount to Pool is the amount of clones you wish to make from the object to pool gameobject")]
    public int amountToPool;

    //bullet Vars
    [Header("Arrow Variables")]
    [Tooltip("Launch Velocity is how powerful the arrow will launch at")]
    public int launchVelocity;
    [Tooltip("Ammo is the amount of arrows able to spawn and fly before reloading")]
    public bool ammo;
    public bool bowEquipped;
    public GameObject aimCam;
    public float hitInfo;

    public GameObject bow;

    public Transform reticle;
    private void Awake()
    {
        SharedInstance = this;
        launchVelocity = 100;
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
            new WaitForSeconds(0.5f);
            launchVelocity = 100;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            launchVelocity = 100;
        }

    }
    public void Fire()
    {
        if (bowEquipped)
        {
            GameObject bullet = Arrow.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = turret.transform.position;
                bullet.transform.rotation = turret.transform.rotation;
                bullet.SetActive(true);
                //bullet.GetComponent<Rigidbody>().velocity = turret.transform.forward * launchVelocity;
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * launchVelocity, ForceMode.Impulse);
            }
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
