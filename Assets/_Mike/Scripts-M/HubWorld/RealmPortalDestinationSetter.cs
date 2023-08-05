using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RealmPortalDestinationSetter : MonoBehaviour
{
    private enum PortalDestinationSM { hubWorld, tutorialLevel, forestLevel, bossRealm }
    [Header("Portal Location Settings")]
    [Tooltip("Set which level this portal will load into.")]
    [SerializeField] private PortalDestinationSM destination;

    [Header("Portal Type Settings")]
    [Tooltip("Set to false to manually select destination of this portal. " +
        "When set to true this portals destination will be set to the Hub World")]
    [SerializeField] private bool isEndOfLevelPortal = false;
    private const string PLAYERTAG = "Player";
    private void Start()
    {
        if (isEndOfLevelPortal)
        {
            destination = PortalDestinationSM.hubWorld;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag(PLAYERTAG))
        {
            ActivatePortal();
        }
    }

    private void ActivatePortal()
    {
        switch (destination)
        {
            case PortalDestinationSM.tutorialLevel:
                SceneManager.LoadScene(1);
                break;

            case PortalDestinationSM.hubWorld:
                SceneManager.LoadScene(2);
                break;

            case PortalDestinationSM.forestLevel:
                SceneManager.LoadScene(3);
                break;

            case PortalDestinationSM.bossRealm:
                SceneManager.LoadScene(4);
                break;

            default:
                Debug.LogWarning("Portal Location SM default");
                break;
        }
    }

}
