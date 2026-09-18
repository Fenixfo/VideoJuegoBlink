using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartValues : MonoBehaviour
{

    public float life=100;
    public float points = 0;
    bool reset = true;

    public static RestartValues restartValues;

    // Start is called before the first frame update
    void Start()
    {
        restartValues = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            ResetValues(life, points);
            reset = false;
        }
        
    }

    public void ResetValues(float life, float points)
    {
        LifeManager.lifeManager.SetLife(life);
        ScoreManager.scoreManager.SetScore(points);
    }

    public void ResetValues()
    {
        LifeManager.lifeManager.SetLife(life);
        ScoreManager.scoreManager.SetScore(points);
    }

}
