using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAndOrbitCam : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Object to follow needs to be added to this field for the camera to follow the player.")]
    Transform focus = default;

    [SerializeField, Range(1f, 20f)]
    [Tooltip("Apply off set distance to the camera.")]
    float distance = 5f;

    [SerializeField, Min(0f)]
    [Tooltip("Camera focus radius" + "This allow us to make the camera focus radius bigger or smaller")]
    float focusRadius = 1f;

    [SerializeField, Range(0f, 1f)]
    [Tooltip("This will center the focus point everythime the player move from the center")]
    float focusCentering = 0.5f;

    Vector2 orbitAngles = new Vector2(45f, 0f);

    [SerializeField, Range(1f, 360f)]
    float rotationSpeed = 90f;

    Vector3 focusPoint;

    ActionInputs inputController;

    [SerializeField, Range(-89f, 89f)]
    float minVerticalAngle = -30f, maxVerticalAngle = 60f;

    [SerializeField, Min(0f)]
    float alignDelay = 10f;

    float lastManualRotationTime;
    Camera regularCamera;

    [SerializeField]
    LayerMask obstructionMask = -1;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    private void Awake()
    {
        focusPoint = focus.position;

        inputController = GetComponent<ActionInputs>();
        transform.localRotation = Quaternion.Euler(orbitAngles);
        regularCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdateFocusPoint();
        ManualRotation();
        Quaternion lookRotation;
        if (ManualRotation())
        {
            ConstrainAngles();
            lookRotation = Quaternion.Euler(orbitAngles);
        }
        else
        {
            lookRotation = transform.localRotation;
        }
        //Quaternion lookRotation = Quaternion.Euler(orbitAngles);
        Vector3 lookDirection = lookRotation * Vector3.forward;
        Vector3 lookPosition = focusPoint - lookDirection * distance;

        Vector3 rectOffset = lookDirection * regularCamera.nearClipPlane;
        Vector3 rectPosition = lookPosition + rectOffset;
        Vector3 castFrom = focus.position;
        Vector3 castLine = rectPosition - castFrom;
        float castDistance = castLine.magnitude;
        Vector3 castDirection = castLine / castDistance;

        if (Physics.BoxCast(
            castFrom, CameraHalfExtends, castDirection, out RaycastHit hit,
            lookRotation, castDistance, obstructionMask))
        //if (Physics.BoxCast(
        //    focusPoint, CameraHalfExtends, -lookDirection, out RaycastHit hit,
        //    lookRotation, distance - regularCamera.nearClipPlane
        //))
        {
            rectPosition = castFrom + castDirection * hit.distance;
            lookPosition = rectPosition - rectOffset;
        }
        transform.SetPositionAndRotation(lookPosition, lookRotation);
    }

    void UpdateFocusPoint()
    {
        Vector3 targetPoint = focus.position;

        if (focusRadius > 0f)
        {
            float distance = Vector3.Distance(targetPoint,focusPoint);

            float time = 1f;
            if (distance > 0.01f && focusCentering > 0f)
            {
                time = Mathf.Pow(1f - focusCentering, Time.deltaTime);
            }
            if (distance > focusRadius)
            {
                time = Mathf.Min(time, focusRadius / distance);
            }
            focusPoint = Vector3.Lerp(targetPoint, focusPoint, time);


        }
    }

    bool ManualRotation()
    { 
        xRotation -= inputController.lookInput.y;
        yRotation += inputController.lookInput.x;
        //const float e = 0.001f;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);

        transform.rotation = rotation;
        //if (xRotation < -e || xRotation > e || yRotation < -e || yRotation > e)
        //{
        //    orbitAngles += rotationSpeed * Time.unscaledDeltaTime * inputController.lookInput;
        //    lastManualRotationTime = Time.unscaledTime;
        //    return true;
        //}
        return false;
    }

    void OnValidate()
    {
        if (maxVerticalAngle < minVerticalAngle)
        {
            maxVerticalAngle = minVerticalAngle;
        }
    }


    void ConstrainAngles () {
		orbitAngles.x =
			Mathf.Clamp(orbitAngles.x, minVerticalAngle, maxVerticalAngle);

		if (orbitAngles.y < 0f) {
			orbitAngles.y += 360f;
		}
		else if (orbitAngles.y >= 360f) {
			orbitAngles.y -= 360f;
		}
	}

    Vector3 CameraHalfExtends
    {
        get
        {
            Vector3 halfExtends;
            halfExtends.y =
                regularCamera.nearClipPlane *
                Mathf.Tan(0.5f * Mathf.Deg2Rad * regularCamera.fieldOfView);
            halfExtends.x = halfExtends.y * regularCamera.aspect;
            halfExtends.z = 0f;
            return halfExtends;
        }
    }

}
