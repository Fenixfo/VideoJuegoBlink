using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void GoLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void GoLevel2()
    {
        SceneManager.LoadScene("Level2");
        RestartValues.restartValues.ResetValues();
    }

    public void GoLevel3()
    {
        SceneManager.LoadScene("Level3");
        RestartValues.restartValues.ResetValues();
    }

    public void GoLevel4()
    {
        SceneManager.LoadScene("Level4");
        RestartValues.restartValues.ResetValues();
    }

}
