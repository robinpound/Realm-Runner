using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lolopupka 
{

public class TargetPoint
{

    public static Vector3 FitToTheGround(Vector3 origin, LayerMask layerMask, float yOffset, float rayLength, float sphereCastRadius)
    {
        RaycastHit hit;

        if(Physics.Raycast(origin + Vector3.up * yOffset, -Vector3.up, out hit, rayLength, layerMask))
        {
            return hit.point;
        }
        else if(Physics.SphereCast(origin + Vector3.up * yOffset, sphereCastRadius, -Vector3.up, out hit, rayLength, layerMask))
        {
            return hit.point;
        } 
        else
        {
            return origin;  
        } 
    }

    public static bool IsValidStepPoint(Vector3 origin, LayerMask layerMask, float yOffset, float rayLength, float sphereCastRadius)
    {
        RaycastHit hit;

        if (Physics.SphereCast(origin + Vector3.up * yOffset, sphereCastRadius, -Vector3.up, out hit, rayLength, layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool IsPointInsideCollider(Vector3 point)
    {
        // to make shure point is not on the collider edge 
        Vector3 yOffset = new Vector3(0, .01f, 0);

        Collider[] hitColiiders = Physics.OverlapSphere(point + yOffset, 0f);
        bool isUnderCollider = Physics.Raycast(point, Vector3.up, 1);
        if (hitColiiders.Length > 0 || isUnderCollider)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}

}
