using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class ForestFragmentEvents : MonoBehaviour
{
    [SerializeField] UnityEvent raisePlatform, openPortal, showPortalCam;

    private int collectedFragments;
    private int raisePlatformThreshold = 2;
    private int raiseEndPortalThreshold = 3;

    private bool isPlatformRaised = false;
    private bool isPortalOpened = false;

    private void Update()
    {
        //collectedFragments = GameManager.Instance.GetFragments();
        Debug.Log("ForestFragmentsEvents Fragment count = " + collectedFragments);

        if (!isPlatformRaised)
        {
            RaisePlatform();
        }
        
        if (!isPortalOpened)
        {
            OpenPortalToHub();
            //isPortalOpened = true;
            //Debug.Log("Call fragment send function");
            //SendFragmetnsToPersistentData(collectedFragments); // change to leave level portal
        }

        
    }

    private void RaisePlatform()
    {
        if (collectedFragments >= raisePlatformThreshold)
        {
            Debug.Log("RaisePlatform Called");
            raisePlatform.Invoke();
            isPlatformRaised = true;
        }
    }

    private void OpenPortalToHub()
    {
        if (collectedFragments >= raiseEndPortalThreshold)
        {
            Debug.Log("Open Portal door");
            openPortal.Invoke();
            showPortalCam.Invoke();
            isPortalOpened = true;
        }
    }

    public void AddToForestFragmentCount()
    {
        collectedFragments++;
    }

    public int GetForestCollectedFragments()
    {
        return collectedFragments;
    }

    public void SendFragmentsToPersistentData()
    {
        Debug.Log("Sent to game manger");
        GameManager.Instance.AddFragmentsFromLevel(collectedFragments);
    }
}
