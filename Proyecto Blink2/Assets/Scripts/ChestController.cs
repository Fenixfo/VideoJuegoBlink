using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ChestController : MonoBehaviour
{
    public int numGolpesAbrir = 2;
    public int costGolpesAbrir = 1;
    //public Slider slider;
    //public Text text;

    Animator anim;
    public Animator animScene;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //GolpeAbrir();
        openChest();
    }

    /*public void GolpeAbrir() 
    {
        if (numGolpesAbrir == 1)
        {
            anim.SetTrigger("ChestOpening");
        }
        else if(numGolpesAbrir == 0)
        {
            anim.SetTrigger("ChestOpen");
        }
    }*/

    bool onChest = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.name.Equals("Hero"))
        {
            onChest = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Hero"))
        {
            onChest = false;
        }
    }

    private void openChest()
    {
        if (Input.GetKeyDown(KeyCode.E) && onChest && numGolpesAbrir>0) 
        {
            Player.player.HeroAction(costGolpesAbrir);
            numGolpesAbrir--;
            if (numGolpesAbrir == 1)
            {
                anim.SetTrigger("ChestOpening");
            }
            else if (numGolpesAbrir == 0)
            {
                anim.SetTrigger("ChestOpen");
                StartCoroutine(LoadScene());
            }
        }
    }

    IEnumerator LoadScene()
    {
        animScene.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(gameObject.name);
    }
}
