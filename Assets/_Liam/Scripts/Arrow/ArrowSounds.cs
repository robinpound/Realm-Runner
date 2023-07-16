using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSounds : MonoBehaviour
{
    [SerializeField] private AudioSource audios;
    [SerializeField] private AudioClip arrow;

    [SerializeField] private bool arrowShot;


    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (arrowShot) 
        {
            audios.clip = arrow;
            audios.Play();
            Invoke(nameof(Reset), 0.5f);
        }
    }
    private void Reset()
    {
        arrowShot = false;
    }
    public void True()
    {
        arrowShot = true;
    }
}
