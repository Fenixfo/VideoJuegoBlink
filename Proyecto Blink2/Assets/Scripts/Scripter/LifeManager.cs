using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{

    public static LifeManager lifeManager;

    float life = 100;
    public Text textBlink;
    public Slider slider;

    private void Start()
    {
        
        if (lifeManager == null)
        {
            lifeManager = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        try {

            if (textBlink == null)
            {
                textBlink = GameObject.Find("TextBlink").GetComponent<Text>();
                textBlink.text = life + "";
            }
            if (slider == null)
            {
                slider = GameObject.Find("SliderBlink").GetComponent<Slider>();
                slider.value = life;
                slider.value = life;
                textBlink.text = slider.value.ToString();
            }

        }
        catch(Exception e)
        {
            Debug.LogException(e);
        }
        
    }

    public void LowerLife(float s)
    {
        life -= s;
        slider.value -= s;
        textBlink.text = slider.value.ToString();
        if (life <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            //SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

        }
    }

    public void SetLife(float newLife)
    {
        life = newLife;
        slider.value = life;
        textBlink.text = slider.value.ToString();
        if (life <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            //SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);


        }
    }


    



}
