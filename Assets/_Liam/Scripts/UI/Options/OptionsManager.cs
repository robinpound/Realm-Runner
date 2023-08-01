using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public float mixer1;
    public float mixer2;
    public float GpCSlider;
    public void ValueChanged()
    {
        mixer1 = 80;
        mixer2 = 80;
    }
    public void Update()
    {
        DontDestroyOnLoad(this);
    }
}
