using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertCollisionController : MonoBehaviour
{

    public GameObject alert;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        alert.GetComponent<Animator>().SetBool("start", true);
        //AlertController.alertController.AlertStart();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        alert.GetComponent<Animator>().SetBool("end", true);
        //AlertController.alertController.AlertEnd();
    }

}
