using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lolopupka
{
public class walkDemonstrate : MonoBehaviour
{
    public float speed;
    public Transform[] targets;

    private int index = 0;

    void Update()
    {
        if(index == targets.Length) index = 0;
        transform.position = Vector3.MoveTowards(transform.position, targets[index].position, Time.deltaTime * speed);

        if(Vector3.Distance(transform.position, targets[index].position) <= .1f)
        {
            index++; 
        }

    }
}
}