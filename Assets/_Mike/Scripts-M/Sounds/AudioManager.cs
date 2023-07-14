using UnityEngine.Audio;
using System;
using UnityEngine;

// Ref Brackeys.
// https://www.youtube.com/watch?v=6OT43pvUyfY

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager Instance { get; private set; }

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
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " NOT FOUND!");
            return;
        }
        s.source.Play();
    }
}

