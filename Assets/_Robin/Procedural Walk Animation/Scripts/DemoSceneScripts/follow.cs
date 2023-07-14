using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lolopupka
{
public class follow : MonoBehaviour
{
    public Transform target;

    public float offset_X;
    public float offset_Y;
    public float offset_Z;

    public enum UpdateMethod {Update, FixedUpdate, LateUpdate}
    public UpdateMethod updateMethod;

    public enum followposition {None, follow_X, follow_y, follow_z, follow_xz, follow_All}
    public followposition followPos;
    public enum CopyRotation {None, rotation_X, rotation_y, rotation_z, rotation_All }
    public CopyRotation copyRot;
    void Update()
    {

        if (updateMethod != UpdateMethod.Update) return;

        switch (followPos)
        {
            case followposition.follow_X:
                transform.position = new Vector3(target.position.x + offset_X, transform.position.y, transform.position.z);
            break;

            case followposition.follow_y:
                transform.position = new Vector3(transform.position.x, target.position.y + offset_Y, transform.position.z);
            break;

            case followposition.follow_z:
                transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + offset_Z);
            break;
            
            case followposition.follow_xz:
                transform.position = new Vector3(target.position.x + offset_X, transform.position.y, target.position.z + offset_Z);
            break;

            case followposition.follow_All:
                transform.position = target.position + new Vector3(offset_X, offset_Y, offset_Z);
            break;

        }

        switch (copyRot)
        {
            case CopyRotation.rotation_X:
                transform.rotation = Quaternion.Euler(target.rotation.eulerAngles.x, transform.rotation.y, transform.rotation.z);
                break;

            case CopyRotation.rotation_y:
                transform.rotation = Quaternion.Euler(transform.rotation.x, target.rotation.eulerAngles.y, transform.rotation.z);
                break;

            case CopyRotation.rotation_z:
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.z, target.rotation.eulerAngles.z);
                break;

            case CopyRotation.rotation_All:
                transform.rotation = Quaternion.Euler(target.rotation.eulerAngles);
                break;
        }

    }

    private void FixedUpdate() 
    {
        if (updateMethod != UpdateMethod.FixedUpdate) return;

        switch (followPos)
        {
            case followposition.follow_X:
                transform.position = new Vector3(target.position.x + offset_X, transform.position.y, transform.position.z);
            break;

            case followposition.follow_y:
                transform.position = new Vector3(transform.position.x, target.position.y + offset_Y, transform.position.z);
            break;

            case followposition.follow_z:
                transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + offset_Z);
            break;
            
            case followposition.follow_xz:
                transform.position = new Vector3(target.position.x + offset_X, transform.position.y, target.position.z + offset_Z);
            break;

            case followposition.follow_All:
                transform.position = target.position + new Vector3(offset_X, offset_Y, offset_Z);
            break;

        }

        switch (copyRot)
        {
            case CopyRotation.rotation_X:
                transform.rotation = Quaternion.Euler(target.rotation.eulerAngles.x, transform.rotation.y, transform.rotation.z);
                break;

            case CopyRotation.rotation_y:
                transform.rotation = Quaternion.Euler(transform.rotation.x, target.rotation.eulerAngles.y, transform.rotation.z);
                break;

            case CopyRotation.rotation_z:
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.z, target.rotation.eulerAngles.z);
                break;

            case CopyRotation.rotation_All:
                transform.rotation = Quaternion.Euler(target.rotation.eulerAngles);
                break;
        }
    }

    private void LateUpdate()
    {
        if (updateMethod != UpdateMethod.LateUpdate) return;

        switch (followPos)
        {
            case followposition.follow_X:
                transform.position = new Vector3(target.position.x + offset_X, transform.position.y, transform.position.z);
            break;

            case followposition.follow_y:
                transform.position = new Vector3(transform.position.x, target.position.y + offset_Y, transform.position.z);
            break;

            case followposition.follow_z:
                transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + offset_Z);
            break;
            
            case followposition.follow_xz:
                transform.position = new Vector3(target.position.x + offset_X, transform.position.y, target.position.z + offset_Z);
            break;

            case followposition.follow_All:
                transform.position = target.position + new Vector3(offset_X, offset_Y, offset_Z);
            break;

        }

        switch (copyRot)
        {
            case CopyRotation.rotation_X:
                transform.rotation = Quaternion.Euler(target.rotation.eulerAngles.x, transform.rotation.y, transform.rotation.z);
                break;

            case CopyRotation.rotation_y:
                transform.rotation = Quaternion.Euler(transform.rotation.x, target.rotation.eulerAngles.y, transform.rotation.z);
                break;

            case CopyRotation.rotation_z:
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.z, target.rotation.eulerAngles.z);
                break;

            case CopyRotation.rotation_All:
                transform.rotation = Quaternion.Euler(target.rotation.eulerAngles);
                break;
        }
    }
}

}
