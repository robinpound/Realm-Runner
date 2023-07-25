using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamepadCSlider : MonoBehaviour
{
    [SerializeField] GameObject optionsManager;
    [SerializeField] Slider GpCSlider;
    [SerializeField] float mixer;

    // Update is called once per frame
    void Update()
    {
        optionsManager = GameObject.FindGameObjectWithTag("OptionsManager");
        // Master Volume Slider
        GpCSlider.value = optionsManager.GetComponent<OptionsManager>().GpCSlider;
        GpCSlider.value = mixer;
        GpCSlider.onValueChanged.AddListener((ms) => {
            mixer = GpCSlider.value;
            optionsManager.GetComponent<OptionsManager>().GpCSlider = GpCSlider.value;
        });
    }
}
