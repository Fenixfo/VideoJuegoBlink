using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public Animator anim;
    public string sceneName;

    public static SceneController sceneController;

    public void Start()
    {
        sceneController = this;
    }

    IEnumerator LoadScene()
    {
        anim.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);

    }

    public void SceneChange()
    {
        StartCoroutine(LoadScene());
    }
}
