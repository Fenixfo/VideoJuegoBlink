using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeController : MonoBehaviour
{
    public Slider sliderVolume;
    public float sliderValue;
    public Image imageMute;

    // Start is called before the first frame update
    void Start()
    {
        sliderVolume.value = PlayerPrefs.GetFloat("volumeAudio", 0.5f);
        AudioListener.volume = sliderVolume.value;
        isMute();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumeAudio", sliderValue);
        AudioListener.volume = sliderVolume.value;
        isMute();
    }

    public void isMute()
    {
        if (sliderValue == 0)
        {
            imageMute.enabled = true;
        }
        else 
        {
            imageMute.enabled = false;
        }
    }
}
