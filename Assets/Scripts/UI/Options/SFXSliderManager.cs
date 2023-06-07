using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSliderManager : MonoBehaviour
{
    public GameObject gameManager;
    public Slider sfxSlider;
    public float mixer;

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        // Master Volume Slider
        sfxSlider.value = gameManager.GetComponent<OptionsManager>().mixer2;
        sfxSlider.value = mixer;
        sfxSlider.onValueChanged.AddListener((ms) => {
            mixer = sfxSlider.value;
            gameManager.GetComponent<OptionsManager>().mixer2 = sfxSlider.value;
        });
    }
}
