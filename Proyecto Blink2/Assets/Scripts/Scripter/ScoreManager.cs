using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager scoreManager;
    

    float score = 0;
    public Text scoreText;

    private void Start()
    {
        if (scoreManager == null)
        {
            scoreManager = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }



    }

    void Update()
    {
        try
        {
            if (scoreText == null)
            {
                scoreText = GameObject.Find("TextScore").GetComponent<Text>();
                scoreText.text = score + "";
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
        
    }

    public void RaiseScore(float s) 
    {
        score += s;
        scoreText.text = score+"";
    }

    public void SetScore(float s)
    {
        score = s;
        scoreText.text = score + "";
    }
}
