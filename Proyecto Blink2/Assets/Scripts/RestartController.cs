using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartController : MonoBehaviour
{

    public static RestartController restartController;

    public Animator animScene;
    // Start is called before the first frame update
    void Start()
    {
        restartController = this;
        //
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ResetGame();
    }

    public void ResetGame()
    {
        StartCoroutine(LoadScene());
    }


    IEnumerator LoadScene()
    {
        animScene.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameOver2"/*"GameOver2"*/);
    }
}
