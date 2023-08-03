using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RealmPortalManager : MonoBehaviour
{
    
    private enum PortalLocationSM { hubWorld, tutorialLevel, forestLevel, bossRealm }
    [Header("Portal Location Settings")]
    [Tooltip("Set which level this portal will load into.")]
    [SerializeField] private PortalLocationSM location;

    private const string PLAYERTAG = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYERTAG))
        {
            ActivatePortal();
        }
    }

    private void ActivatePortal()
    {
        switch (location)
        {
            case PortalLocationSM.hubWorld:
                SceneManager.LoadScene(1);
                break;
            case PortalLocationSM.tutorialLevel:
                SceneManager.LoadScene(2);
                break;

            case PortalLocationSM.forestLevel:
                SceneManager.LoadScene(3);
                break;

            case PortalLocationSM.bossRealm:
                SceneManager.LoadScene(4);
                break;

            default:
                Debug.LogWarning("Portal Location SM default");
                break;
        }
    }

}
