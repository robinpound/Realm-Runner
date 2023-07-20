using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterSliderManager : MonoBehaviour
{
    [SerializeField] GameObject optionsManager;
    [SerializeField] Slider masterSlider;
    [SerializeField] float mixer;

    // Update is called once per frame
    void Update()
    {
        optionsManager = GameObject.FindGameObjectWithTag("OptionsManager");
        // Master Volume Slider
        masterSlider.value = optionsManager.GetComponent<OptionsManager>().mixer;
        mixer = masterSlider.value;
        masterSlider.onValueChanged.AddListener((ms) => {
            mixer = masterSlider.value;
            optionsManager.GetComponent<OptionsManager>().mixer = masterSlider.value;
        });
    }

}
