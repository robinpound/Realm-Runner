using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterSliderManager : MonoBehaviour
{
    public GameObject gameManager;
    public Slider masterSlider;
    public float mixer;

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        // Master Volume Slider
        masterSlider.value = gameManager.GetComponent<OptionsManager>().mixer;
        mixer = masterSlider.value;
        masterSlider.onValueChanged.AddListener((ms) => {
            mixer = masterSlider.value;
            gameManager.GetComponent<OptionsManager>().mixer = masterSlider.value;
        });
    }

}
