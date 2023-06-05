using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text sliderText;


    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener((v) => {
            sliderText.text = v.ToString("0.00");
        });
    }
}
