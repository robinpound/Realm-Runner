using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


namespace Lolopupka
{
public class proceduralAnimation : MonoBehaviour
{
    [Tooltip("Step distance is used to calculate step height. When character makes a short step there is no need to rase foot all the way up so if the current step distance is less then this step distance value step height will be lover then usual.")]
    [SerializeField] private float stepDistance = 1f;
    [SerializeField] private float stepHeight = 1f;
    [SerializeField] private float stepSpeed = 5f;
    [Tooltip("Velocity multiplier used to make step wider when moving on high speed (if you toggle the show gizmoz below and move your model around you could clearly see what this does. The blue spheres represent the target step points and will move further ahead if you increase velocity multiplier)")]
    [SerializeField] private float velocityMultiplier = .4f;
    [SerializeField] private float cycleSpeed = 1;
    [Tooltip("how often in seconds legs will move (every one second by default)")]
    [SerializeField] private float cycleLimit = 1;
    [Tooltip("•	If you want some legs to move together enable the Set Timings Manually. And add as many timings as your model has legs. The first Manual Timing is relative to the first leg in the leg IK targets array etc. For example: if your character has four legs and you want two left legs move first and two right to move second you need to set timings to [0.5, 0.5, 0, 0]. That means that first two legs will move and only 0.5 second later the second two will move. ")]
    [SerializeField] private bool SetTimingsManually;
    [SerializeField] private float[] manualTimings;
    [Tooltip("If you want only one leg to move at a time then set Timings offset as one divided by the number of legs. For example: if your character has four legs you need to set this as ¼ = 0.25. The script will offset the cycle of every leg by 0.25 seconds. ")]
    [SerializeField] private float timigsOffset = 0.25f;
    [Tooltip("Velocity clamp limits the step distance while moving on high speed.")]
    [SerializeField] private float velocityClamp = 4;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private AnimationCurve legArcPathY = new AnimationCurve(new Keyframe(0, 0, 0, 2.5f), new Keyframe(0.5f, 1), new Keyframe(1, 0, -2.5f, 0));
    [SerializeField] private AnimationCurve easingFunction = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [SerializeField] private Transform[] legIktargets;

    [Header("Raycasts")]
    public bool showGizmoz = true;
    [SerializeField] float legRayoffset = 3;
    [SerializeField] float legRayLength = 6;
    [Tooltip("Ground check range for every leg")]
    [SerializeField] float sphereCastRadius = 1;

    [Header("Advansed")]
    [Tooltip("Refresh Timings rate updates timings and sets it to default value to make sure every leg is making step at the right time. If your character moves slowly, you can set it as some big value like 100 so it updates only every 100 seconds but if not, you need to lower this value. For example: fast pink robot in demo scene has this value set as 10. ")]
    [SerializeField] private float refreshTimingRate = 60f;

    public EventHandler<Vector3> OnStepFinished;

    private Vector3[] lastLegPositions;
    private Vector3[] defaultLegPositions;
    private Vector3[] raycastPoints;
    private Vector3[] targetStepPosition;
    private Vector3 velocity;
    private Vector3 lastVelocity;
    private Vector3 lastBodyPos;
    
    private float[] footTimings;
    private float[] targetTimings;
    private float[] totalDistance;
    private float clampDevider;
    private float[] arcHeitMultiply;

    private int nbLegs;
    private int indexTomove;
    
    private bool[] isLegMoving;

    private void Start()
    {
        indexTomove = -1;
        nbLegs = legIktargets.Length;

        defaultLegPositions = new Vector3[nbLegs];
        lastLegPositions = new Vector3[nbLegs];
        targetStepPosition = new Vector3[nbLegs];
        
        isLegMoving = new bool[nbLegs];
        footTimings = new float[nbLegs];
        arcHeitMultiply = new float[nbLegs];
        totalDistance = new float[nbLegs];

        if(SetTimingsManually && manualTimings.Length != nbLegs)
        {
            Debug.LogError("manual footTimings length should be equal to the leg count");
        }


        for (int i = 0; i < nbLegs; ++i)
        {
            if(SetTimingsManually)
            {
                footTimings[i] = manualTimings[i];
            }
            else
            {
                footTimings[i] = i * timigsOffset;
            }

            lastLegPositions[i] = legIktargets[i].position;
            defaultLegPositions[i] = legIktargets[i].localPosition;
        }

        //to make sure timings are in synch
        StartCoroutine(UpdateTimings(refreshTimingRate));
    }

    private void Update()
    {   
        velocity = (transform.position - lastBodyPos) / Time.deltaTime;
        velocity = Vector3.MoveTowards(lastVelocity, velocity, Time.deltaTime * 45f);
        clampDevider = 1 / Remap(velocity.magnitude, 0, velocityClamp, 1, 2);

        lastVelocity = velocity;

        indexTomove = -1;

        for (int i = 0; i < nbLegs; ++i)
        {
            // fit legs to the ground
            if(i == indexTomove) continue;
            legIktargets[i].position = TargetPoint.FitToTheGround(lastLegPositions[i], layerMask, legRayoffset, legRayLength, sphereCastRadius);
        }

        //to move legs more frequently when speed is close to max speed
        float cycleSpeedMultiplyer = Remap(velocity.magnitude, 0f, velocityClamp, 1f, 2f);

        for (int i = 0; i < nbLegs; ++i)
        {
            //move legs when everytime footTimings reache limit
            footTimings[i] += Time.deltaTime * cycleSpeed * cycleSpeedMultiplyer;

            if(footTimings[i] >= cycleLimit) 
            {
                
                footTimings[i] = 0;

                indexTomove = i;
                SetUp(i);
            }
        }

        lastBodyPos = transform.position;
    }

    public void SetUp(int index)
    {
        // finding target step point based on body velocity 
        Vector3 v = transform.TransformPoint(
            defaultLegPositions[index]) + 
            velocity.normalized * Mathf.Clamp(velocity.magnitude, 0, velocityClamp * clampDevider) * velocityMultiplier;
        targetStepPosition[index] = TargetPoint.FitToTheGround(v, layerMask, legRayoffset, legRayLength, sphereCastRadius);

        totalDistance[index] = GetDistanceToTarget(index);

        float distance = Vector3.Distance(legIktargets[index].position, targetStepPosition[index]);
        arcHeitMultiply[index] = distance / stepDistance;

        if(targetStepPosition[index] != Vector3.zero && TargetPoint.IsValidStepPoint(targetStepPosition[index], layerMask, legRayoffset, legRayLength, sphereCastRadius))
        {
            StartCoroutine(MakeStep(targetStepPosition[index], indexTomove));
        }
    }
    
    private IEnumerator MakeStep(Vector3 targetPosition, int index)
    {
        float current = 0;

        while(current < 1)
        {
            current += Time.deltaTime * stepSpeed;

            float positionY = legArcPathY.Evaluate(current) * stepHeight * Mathf.Clamp(arcHeitMultiply[index], 0, 1f);

            Vector3 desiredStepPosition = new Vector3(
                targetPosition.x, 
                positionY + targetPosition.y, 
                targetPosition.z);

            legIktargets[index].position = Vector3.Lerp(lastLegPositions[index], desiredStepPosition, easingFunction.Evaluate(current));

            yield return null;
        }
        
        LegReachedTargetPosition(targetPosition, index);  
            
    }

    private void LegReachedTargetPosition(Vector3 targetPosition, int index)
    {
        indexTomove = -1;
        legIktargets[index].position = targetPosition;
        lastLegPositions[index] = legIktargets[index].position;

        // Event for visual and sound effects
        if(totalDistance[index] > .3f)
        {
            OnStepFinished?.Invoke(this, targetPosition);
        }

        isLegMoving[index] = false;
    }

    
    private IEnumerator UpdateTimings(float time)
    {
        yield return new WaitForSecondsRealtime(time);

        for (int i = 0; i < nbLegs; ++i)
        {
            if(SetTimingsManually)
            {
                footTimings[i] = manualTimings[i];
            }
            else
            {
                footTimings[i] = i * timigsOffset;
            }
        }

        StartCoroutine(UpdateTimings(refreshTimingRate));
    }

    public Transform[] GetLegArray()
    {
        return legIktargets;
    }

    private float GetDistanceToTarget(int index)
    {
        return Vector3.Distance(legIktargets[index].position, transform.TransformPoint(defaultLegPositions[index]));
    }

    public float GetDistanceToGround(int index)
    {
        Vector3 leg = legIktargets[index].position;
        Ray ray = new Ray(leg + Vector3.up * .1f, -Vector3.up);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, layerMask))
        {
            return Vector3.Distance(leg, hit.point);
        }

        return 0f;
    }

    public bool IsLegMoving(int index)
    {
        return isLegMoving[index];
    }

    public LayerMask GetLayerMask()
    {
        return layerMask;
    }

    public float GetAverageLegHeight()
    {
        //to calculate body position and rase it when leg is moving based on legs distance to ground
        float averageHeight = 0;
        for (int i = 0; i < nbLegs; ++i)
        {
            averageHeight += GetDistanceToGround(i);
        }

        averageHeight /= nbLegs;
        return averageHeight;
    }

    public static float Remap(float input, float oldLow, float oldHigh, float newLow, float newHigh) 
    {
        float t = Mathf.InverseLerp(oldLow, oldHigh, input);
        return Mathf.Lerp(newLow, newHigh, t);
    }


    private void OnDrawGizmosSelected()
    {
        if(!showGizmoz || !Application.IsPlaying(this))
        {
            return;
        }

        for (int i = 0; i < nbLegs; ++i)
        {
            //target points
            Vector3 v = transform.TransformPoint(
            defaultLegPositions[i]) + velocity.normalized * Mathf.Clamp(velocity.magnitude, 0, velocityClamp * clampDevider) * velocityMultiplier;
            Vector3 v2 = TargetPoint.FitToTheGround(v, layerMask, legRayoffset, legRayLength, sphereCastRadius);

            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(v2, .2f);

            // default leg positions and ground check range 
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.TransformPoint(defaultLegPositions[i]) + Vector3.up * legRayoffset, -Vector3.up * legRayLength);
            Gizmos.DrawWireSphere(transform.TransformPoint(defaultLegPositions[i]), sphereCastRadius);
        }
    }
}

}
