using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSliderManager : MonoBehaviour
{
    [SerializeField] GameObject optionsManager;
    [SerializeField] Slider sfxSlider;
    [SerializeField] float mixer;

    // Update is called once per frame
    void Update()
    {
        optionsManager = GameObject.FindGameObjectWithTag("OptionsManager");
        // Master Volume Slider
        sfxSlider.value = optionsManager.GetComponent<OptionsManager>().mixer2;
        sfxSlider.value = mixer;
        sfxSlider.onValueChanged.AddListener((ms) => {
            mixer = sfxSlider.value;
            optionsManager.GetComponent<OptionsManager>().mixer2 = sfxSlider.value;
        });
    }
}
