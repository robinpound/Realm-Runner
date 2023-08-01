using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text sliderText;

    private void Update()
    {
        sliderText.text = slider.value.ToString("0");
    }
}
