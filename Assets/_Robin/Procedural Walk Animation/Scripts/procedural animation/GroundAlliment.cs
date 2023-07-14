using UnityEngine;

namespace Lolopupka
{
public class GroundAlliment : MonoBehaviour
{
    [SerializeField] float checkRange = 1f;
    [SerializeField] float orientationSpeed = 50f;
    [SerializeField] LayerMask layerMask;

    private Vector3 lastUp;
    private float t;
    void Update()
    {
        t += Time.deltaTime;

        RaycastHit hit;
        Physics.Raycast(transform.position + Vector3.up * 1f, -Vector3.up, out hit, checkRange, layerMask);

        Vector3 newUp = Vector3.Lerp(lastUp, hit.normal, t * orientationSpeed);
        var targetRotation = GetTargetRotation(transform.forward, newUp);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, orientationSpeed * Time.deltaTime);
        
        lastUp = transform.up;
    }

    Quaternion GetTargetRotation(Vector3 approximateForward, Vector3 exactUp) 
    {
        Quaternion zToUp = Quaternion.LookRotation(exactUp, -approximateForward);
        Quaternion yToz = Quaternion.Euler(90, 0, 0);
        return zToUp * yToz;
    }
}
}
