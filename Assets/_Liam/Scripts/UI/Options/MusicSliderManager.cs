using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSliderManager : MonoBehaviour
{
    //[SerializeField] GameObject optionsManager;
    [SerializeField] Slider musicSlider;
    [SerializeField] float mixer;
    // Update is called once per frame
    void Update()
    {
        //optionsManager = GameObject.FindGameObjectWithTag("OptionsManager");
        // Master Volume Slider
        musicSlider.value = OptionsManager.Instance.mixer1;
        musicSlider.value = mixer;
        musicSlider.onValueChanged.AddListener((ms) => {
            mixer = musicSlider.value;
            OptionsManager.Instance.mixer1 = musicSlider.value;
        });
    }
    public void ResetSlider()
    {
        musicSlider.value = 80;
    }
}
