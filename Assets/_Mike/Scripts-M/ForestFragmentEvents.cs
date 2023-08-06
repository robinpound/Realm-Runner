using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ForestFragmentEvents : MonoBehaviour
{
    [SerializeField] UnityEvent raisePlatform;

    private int collectedFragments;
    private int raisePlatformThreshold = 2;

    private bool isPlatformRaised = false;
    private bool isPortalOpened = false;

    private void Update()
    {
        //collectedFragments = GameManager.Instance.GetFragments();
        Debug.Log("ForestFragmentsEvents Fragment count = " + collectedFragments);

        if (!isPlatformRaised)
        {
            RaisePlatform();
            isPlatformRaised = true;
        }
        
        if (!isPortalOpened)
        {
            isPortalOpened = true;
            SendFragmetnsToPersistentData(collectedFragments);
        }
    }

    private void RaisePlatform()
    {
        //Debug.Log("RaisePlatform Called");
        int tutorialLevelOffset = 1;
        if (collectedFragments >= raisePlatformThreshold - tutorialLevelOffset)
        {
            raisePlatform.Invoke();
        }
    }

    public void OpenPortalToHub()
    {
        //Invoke open portal
    }

    public void AddToForestFragmentCount()
    {
        collectedFragments++;
    }

    private void SendFragmetnsToPersistentData(int fragments)
    {
        GameManager.Instance.AddFragmentsFromLevel(fragments);
    }


}
