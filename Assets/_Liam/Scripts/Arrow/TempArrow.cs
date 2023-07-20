using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempArrow : MonoBehaviour
{
    public GameObject bowFirePoint;
    public GameObject arrowPref;
    public float arrowSpeed = 1000f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var arrow = Instantiate(arrowPref, bowFirePoint.transform.position, bowFirePoint.transform.rotation);
            arrow.GetComponent<Rigidbody>().velocity = bowFirePoint.transform.forward * arrowSpeed;
        }
    }
}
