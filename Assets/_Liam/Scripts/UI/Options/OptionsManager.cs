using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public static OptionsManager Instance { get; private set; } // Singleton used in MusicSliderManager script.
    public float mixer1;
    public float mixer2;
    public float GpCSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
        
    }
    public void ValueChanged()
    {
        mixer1 = 0;
        mixer2 = 0;
    }
}
