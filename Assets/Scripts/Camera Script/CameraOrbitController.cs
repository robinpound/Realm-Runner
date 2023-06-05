using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitController : MonoBehaviour
{
    public Transform cameraFollow;
    public Vector3 playerLookInput = Vector3.zero;
    Vector3 playerPreviewsLookAtPoint = Vector3.zero;
    float cameraPitch = 0.0f;
    [SerializeField]
    float playerLookAtPointLerpTime = 0.35f;
    [SerializeField]
    public float rotationSpeedMultiplier = 180.0f;
    [SerializeField]
    float speedPitchMultiplier = 180.0f;
    bool invertMouseYaxis = true;

    MovementController lookAction;
    // Start is called before the first frame update
    void Start()
    {
        lookAction = FindObjectOfType<MovementController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 GetLookInput(){
        playerPreviewsLookAtPoint = playerLookInput;
        playerLookInput = new Vector3(lookAction.cameraAimInput.x,(invertMouseYaxis ? -lookAction.cameraAimInput.y : lookAction.cameraAimInput.y), 0.0f);
        return Vector3.Lerp(playerPreviewsLookAtPoint, playerLookInput * Time.deltaTime, playerLookAtPointLerpTime);
    }
    public void PitchCamera(){
        Vector3 rotationValues = cameraFollow.rotation.eulerAngles;
        cameraPitch += playerLookInput.y * speedPitchMultiplier;
        cameraPitch = Mathf.Clamp(cameraPitch, -89.9f, 89.9f);

        cameraFollow.rotation = Quaternion.Euler(cameraPitch, rotationValues.y, rotationValues.z);
    }

}
