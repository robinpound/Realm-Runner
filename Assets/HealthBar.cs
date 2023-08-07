using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider bossHealthSlider;
    public void MinusHealth() => bossHealthSlider.value -= 5;
    public void HealthHealth() => bossHealthSlider.value += 15;
}