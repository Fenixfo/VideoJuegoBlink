using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopController : MonoBehaviour
{

    AudioSource aSource;
    public AudioClip dying;


    // Start is called before the first frame update
    void Start()
    {
        aSource = transform.parent.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "Hero")
        {
            float lifeTime = 0.3f;
            transform.parent.GetComponent<Animator>().SetBool("death", true);
            Destroy(transform.parent.gameObject, lifeTime);
            aSource.PlayOneShot(dying);

        }
    }

}
