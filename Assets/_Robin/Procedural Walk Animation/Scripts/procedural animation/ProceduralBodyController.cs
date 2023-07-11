using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Lolopupka
{
public class ProceduralBodyController : MonoBehaviour
{
    [SerializeField] private proceduralAnimation proceduralAnimation;
    [SerializeField] private Vector3 bodyOffset;
    [SerializeField] private float bodySpeed = 10f;
    [Tooltip("How much legs affect body position")]
    [SerializeField] private float legsImpact = 1f;
    [SerializeField] private float height = 1f;
    [Tooltip("Calculates body position based on average leg positions, use body offset vector to set desired body position")]
    [SerializeField] private bool smartBodyPosition = true;
    [Tooltip("rotates body towards the ground with speed of bodyRotationSpeed")]
    [SerializeField] private bool bodyOrientation;
    [SerializeField] private float bodyRotationSpeed = 25f;

    [Header("Raycasts")]
    [SerializeField] private bool showGizmos = true;
    [Tooltip("body ground check range")]
    [SerializeField] private float sphereCastRadius = 2f;
    [SerializeField] private float racastOffset = 2f;
    [SerializeField] private float raycastRange = 6f;

    private LayerMask layerMask;

    private Transform[] legTargets;
    private int nbLegs;
    private Vector3 lastBodyUp;

    private void Awake() 
    {
        layerMask = proceduralAnimation.GetLayerMask();
        lastBodyUp = transform.up;
    }

    private void Start() 
    {  
        legTargets = proceduralAnimation.GetLegArray();
        nbLegs = legTargets.Length;
    }

    void LateUpdate()
    {
        HandleBodyPosition();

        if(bodyOrientation)
        {
            HandleBodyRotationRaycasts();
        }
    }

    private void HandleBodyRotationRaycasts()
    {
        //calculate averege normals based on surface under legs

        RaycastHit hit;

        Vector3 averegeNormal = Vector3.zero;

        for (int i = 0; i < nbLegs; ++i)
        {
            if(!Physics.Raycast(legTargets[i].position + Vector3.up * .1f, -Vector3.up, out hit, 3f, layerMask))
            {
                continue;
            }
            averegeNormal += hit.normal;
        }

        Vector3 newUp = Vector3.MoveTowards(lastBodyUp.normalized, averegeNormal.normalized, Time.deltaTime * bodyRotationSpeed);

        var targetRotation = BodyRotation(transform.forward, newUp);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, bodyRotationSpeed * Time.deltaTime);

        lastBodyUp = transform.up;
    }

    Quaternion BodyRotation(Vector3 approximateForward, Vector3 exactUp) 
    {
        Quaternion zToUp = Quaternion.LookRotation(exactUp, -approximateForward);
        Quaternion yToz = Quaternion.Euler(90, 0, 0);
        return zToUp * yToz;
    }

    private void HandleBodyPosition()
    {
        RaycastHit hit;

        if(Physics.SphereCast(transform.position + Vector3.up * racastOffset, sphereCastRadius, - Vector3.up, out hit, raycastRange, layerMask))
        {
            if(smartBodyPosition)
            {
                Vector3 desiredBodyPos = new Vector3(
                    GetAverageBodyPosition().x,
                    hit.point.y + height + legInpact(),
                    GetAverageBodyPosition().z);


                Vector3 v = transform.InverseTransformPoint(desiredBodyPos) + bodyOffset;
                Vector3 v2 = transform.TransformPoint(v);

                transform.position = Vector3.Lerp(transform.position, v2, Time.deltaTime * bodySpeed);
            }
            else
            {
                Vector3 desiredBodyPos = new Vector3(
                    transform.position.x,
                    hit.point.y + height + legInpact(),
                    transform.position.z);


                Vector3 v = transform.InverseTransformPoint(desiredBodyPos) + bodyOffset;
                Vector3 v2 = transform.TransformPoint(v);

                transform.position = Vector3.Lerp(transform.position, v2, Time.deltaTime * bodySpeed);
            }
        }
    }

    private Vector3 GetAverageBodyPosition()
    {
        Vector3 pos = Vector3.zero;

        for (int i = 0; i < nbLegs; ++i)
        {
            pos += legTargets[i].position;
        }

        pos /= legTargets.Length;

        return pos;
    }

    private float legInpact()
    {
        return proceduralAnimation.GetAverageLegHeight() * legsImpact;
    }

    private void OnDrawGizmosSelected() 
    {
        if(showGizmos)
        {
            Debug.DrawRay(transform.position + Vector3.up * racastOffset, - Vector3.up * raycastRange, Color.green);
            Gizmos.DrawWireSphere(transform.position, sphereCastRadius);
        }
    }

}
}
