using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertController : MonoBehaviour
{


    public static AlertController alertController;
    // Start is called before the first frame update
    void Start()
    {
        alertController = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AlertStart() {
        gameObject.GetComponent<Animator>().SetBool("start", true);
    }
    public void AlertEnd()
    {
        gameObject.GetComponent<Animator>().SetBool("end", true);
    }
}
