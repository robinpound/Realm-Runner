using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public float mixer;
    public float mixer1;
    public float mixer2;
    public float GpCSlider;

    public void Update()
    {
        DontDestroyOnLoad(this);
    }
}
