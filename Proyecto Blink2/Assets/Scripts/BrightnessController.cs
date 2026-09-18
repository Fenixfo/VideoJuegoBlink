using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BrightnessController : MonoBehaviour
{
    public Slider sliderBrightness;
    public float sliderValue;
    public Image panelBrightness;

    // Start is called before the first frame update
    void Start()
    {
        sliderBrightness.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        panelBrightness.color = new Color(panelBrightness.color.r, panelBrightness.color.g, panelBrightness.color.b, sliderBrightness.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        panelBrightness.color = new Color(panelBrightness.color.r, panelBrightness.color.g, panelBrightness.color.b, sliderBrightness.value);
    }

}
