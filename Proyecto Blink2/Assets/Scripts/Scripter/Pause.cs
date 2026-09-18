using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{

    bool active;
    public Text textPause;

    // Start is called before the first frame update
    void Start()
    {
        textPause.enabled = false;
        //textPause.transform.GetChild(0).gameObject.SetActive(active);
        SetChildren();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("p"))
        {
            Debug.Log(gameObject.name);
            active = !active;
            textPause.enabled = active;
            Time.timeScale = (active) ? 0 : 1;
            //textPause.transform.GetChild(0).gameObject.SetActive(active);
            SetChildren();
        }
    }

    public void Resume()
    {
        active = false;
        textPause.enabled = active;
        Time.timeScale = (active) ? 0 : 1;
        //textPause.transform.GetChild(0).gameObject.SetActive(active);
        SetChildren();
    }

    public void Menu()
    {
        active = false;
        textPause.enabled = active;
        Time.timeScale = (active) ? 0 : 1;
        //textPause.transform.GetChild(0).gameObject.SetActive(active);
        SetChildren();
        SceneManager.LoadScene("MainMenu");
    }

    private void SetChildren()
    {
        textPause.transform.GetChild(0).gameObject.SetActive(active);
        textPause.transform.GetChild(1).gameObject.SetActive(active);
        textPause.transform.GetChild(2).gameObject.SetActive(active);
    }

}
