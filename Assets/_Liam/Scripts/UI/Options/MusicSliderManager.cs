using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSliderManager : MonoBehaviour
{
    public GameObject gameManager;
    public Slider musicSlider;
    public float mixer;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.FindGameObjectWithTag("OptionsManager");
        // Master Volume Slider
        musicSlider.value = gameManager.GetComponent<OptionsManager>().mixer1;
        musicSlider.value = mixer;
        musicSlider.onValueChanged.AddListener((ms) => {
            mixer = musicSlider.value;
            gameManager.GetComponent<OptionsManager>().mixer1 = musicSlider.value;
        });
    }
}
