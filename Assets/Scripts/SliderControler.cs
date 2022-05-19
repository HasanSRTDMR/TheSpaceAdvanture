using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControler : MonoBehaviour
{

    Slider slider;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1;
    }
    public void SliderValue(int max,int value)
    {
        int sliderValue =max-value;
        slider.maxValue = max;
        slider.value = sliderValue;
    }
}
