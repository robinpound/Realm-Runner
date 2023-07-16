using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Lolopupka
{
    
[RequireComponent(typeof(AudioSource))]
public class StepEffects : MonoBehaviour
{
    [SerializeField] private AudioClip[] stepSVX;
    [SerializeField] private GameObject stepVFX;

    private proceduralAnimation proceduralAnimation;
    private AudioSource audioSource;
    void Start()
    {
        TryGetComponent<AudioSource>(out audioSource);

        if (TryGetComponent<proceduralAnimation>(out proceduralAnimation))
        {
            proceduralAnimation.OnStepFinished += ProceduralAnimation_OnStepFinished;
        }
        else
        {
            Debug.LogError("procedural animation script required on " + gameObject);
        }
    }

    private void ProceduralAnimation_OnStepFinished(object sender, Vector3 LegPosition)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(stepSVX[UnityEngine.Random.Range(0, stepSVX.Length - 1)]);
        }

        if(stepVFX != null)
        {
            Instantiate(stepVFX, LegPosition, Quaternion.identity);
        }
    }
}
}
