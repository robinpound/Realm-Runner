using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerStats>().TakeDamage(1000);
        }
    }
}
