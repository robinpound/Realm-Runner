using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobShadow : MonoBehaviour
{
    [SerializeField] GameObject fakeShadow;
    [SerializeField] float blobOffsetY = 1f;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        {
            Vector3 position = hit.point;
            position.y += 0.01f;
            fakeShadow.transform.position = position + new Vector3(0, blobOffsetY, 0);
        }
    }

}
