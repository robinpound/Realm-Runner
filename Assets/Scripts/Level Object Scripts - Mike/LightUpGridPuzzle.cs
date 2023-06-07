using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightUpGridPuzzle : MonoBehaviour
{
    [SerializeField]
    private GameObject light;
    private GameObject instantiatedLight;
    //Vector3 rayCastVector;
    private const string PLAYER = "Player";
    private bool hasLightSpawned = false;

    private void Start()
    {
        Vector3 lightSpawnOffsetY = new Vector3(0f, .5f, 0f);
        instantiatedLight = Instantiate(light, transform.position + lightSpawnOffsetY, Quaternion.identity);
        instantiatedLight.SetActive(false);
    }

    private void Update()
    {
        Debug.Log("Light " + hasLightSpawned);
    }
    
    
    
    private void OnTriggerEnter(Collider other)
    { 
            if (other.gameObject.CompareTag(PLAYER))
            {
                Debug.Log(other.gameObject.name + " has landed ");
                instantiatedLight.SetActive(!hasLightSpawned);
                hasLightSpawned = !hasLightSpawned;
            }
        
        /*
        Debug.Log("eagle has landed");
        if (other.gameObject.CompareTag(PLAYER) && !hasLightSpawned)
        {
            instantiatedLight.SetActive(true);
            hasLightSpawned=true;
            Debug.Log(hasLightSpawned);
        }
        
        else if (other.gameObject.CompareTag(PLAYER) && hasLightSpawned)
        {
            Debug.Log("hasLightSpawned");
            instantiatedLight.SetActive(false);
            hasLightSpawned = false;
        }
        */
        
        
    }



    /*
    
    private void Update()
    {
        DrawCubeRayCast();
        Debug.Log("Light " + hasLightSpawned);
        RaycastHit hit;

        if(Physics.Raycast(transform.position, rayCastVector, out hit))
        {
            Debug.Log(hit.collider.name + " detected");

            if (hit.collider.CompareTag(PLAYER) && hasLightSpawned == false)
            {
                instantiatedLight.SetActive(true);
                hasLightSpawned = true;
            }
            
            
        }
    }

    private void DrawCubeRayCast()
    {
        float rayCastLength = 2f;
        rayCastVector = transform.TransformDirection(Vector3.up) * rayCastLength;
        Debug.DrawRay(transform.position, rayCastVector, Color.magenta);
    }
    */
}
