using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwordSounds : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private AudioSource audios;
    [SerializeField] private AudioClip unSheath;

    [SerializeField] private bool swordUnsheath;
    [SerializeField] private bool swordEquipped;
    [SerializeField] private int timer;

    [SerializeField] private UnityEvent SoundActivate;

    private void Start()
    {
        //swordUnsheath = true;
    }
    private void Update()
    {
        // Constantlu gets swordEquipped bool from Sword Script
        swordEquipped = player.GetComponent<Sword>().swordEquipped;
    }
    // True function to Un-Sheath sword
    public void True()
    {
        if (!swordUnsheath && timer == 0 && swordEquipped)
        {
            StartCoroutine(Unsheath());
        }
    }
    // False function to Sheath sword
    public void False()
    {
        if (swordUnsheath && timer == 0 && !swordEquipped)
        {
            StartCoroutine(Sheath());
            //swordUnsheath = false;
        }
    }
    private void Reset()
    {
        timer = 0;
    }
    IEnumerator Unsheath()
    {
        swordUnsheath = true;
        yield return new WaitForSeconds(0.25f);
        SoundActivate.Invoke();
        timer = 1;
        Invoke(nameof(Reset), 0.5f);
    }
    IEnumerator Sheath()
    {
        swordUnsheath = false;
        yield return new WaitForSeconds(0.1f);
        SoundActivate.Invoke();
        timer = 1;
        Invoke(nameof(Reset), 0.5f);
    }




    public void UnSheath()
    {
        audios.clip = unSheath;
        audios.Play();
    }
}
