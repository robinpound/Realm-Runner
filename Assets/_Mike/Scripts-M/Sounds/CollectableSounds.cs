using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CollectableSounds : MonoBehaviour
{
    public static CollectableSounds Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null) // Check if there is an instance already.
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Dont destroy game object when new scene loads.

        }
        else
        {
            Destroy(gameObject); // Don't allow 2 singletons.
        }

       
    }

    public void PlaySoundOnCoinCollected()
    {
        GetComponent<AudioSource>().Play();
    }

}
