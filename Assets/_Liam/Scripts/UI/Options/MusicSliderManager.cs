using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSliderManager : MonoBehaviour
{
    [SerializeField] GameObject optionsManager;
    [SerializeField] Slider musicSlider;
    [SerializeField] float mixer;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        optionsManager = GameObject.FindGameObjectWithTag("OptionsManager");
        // Master Volume Slider
        musicSlider.value = optionsManager.GetComponent<OptionsManager>().mixer1;
        musicSlider.value = mixer;
        musicSlider.onValueChanged.AddListener((ms) => {
            mixer = musicSlider.value;
            optionsManager.GetComponent<OptionsManager>().mixer1 = musicSlider.value;
        });
    }
}
