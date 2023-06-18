using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveController : MonoBehaviour
{
   public Vector3 ConvertToCameraSpace(Vector3 vectorToRotate)
    {
      // store the Y value of the original vector to rotate 
      float currentYValue = vectorToRotate.y;

      // get the forward and right directional vectors of the camera
      Vector3 cameraForward = Camera.main.transform.forward;
      Vector3 cameraRight = Camera.main.transform.right;

      // remove the Y values to ignore upward/downward camera angles
      cameraForward.y = 0;
      cameraRight.y = 0;

      // re-normalize both vectors so they each have a magnitude of 1
      cameraForward = cameraForward.normalized;
      cameraRight = cameraRight.normalized;

      // rotate the X and Z VectorToRotate values to camera space
      Vector3 cameraForwardZProduct = vectorToRotate.z * cameraForward;
      Vector3 cameraRightXProduct = vectorToRotate.x * cameraRight;

      // the sum of both products is the Vector3 in camera space and set Y value
      Vector3 vectorRotatedToCameraSpace = cameraForwardZProduct + cameraRightXProduct;
      vectorRotatedToCameraSpace.y = currentYValue;
      return vectorRotatedToCameraSpace;
    }
}
