using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{


    public float speed = 6;
    public float lifeTime = 2;
    public Vector3 direction = new Vector3(-1,0,0);

    Vector3 stepVector;
    Rigidbody2D rgb;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        rgb = GetComponent<Rigidbody2D>();
        stepVector = speed * direction.normalized;
    }
    
    // Update is called once per frame
    void Update()
    {
        rgb.velocity = stepVector;
       /* if (Input.GetKeyDown("b"))
        {
            //if (Player.player.energy)
            //{
                Instantiate(Mace, gameObject.GetComponent<Transform>().position, new Quaternion());
            //}
            //MaceController.maceController.Shoot(100f);
            //MaceController.maceController.Shoot(100f);
            //MaceController.Shoot(100f);
        }*/

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.transform.name == "Hero")
        //{
            Destroy(gameObject);
        //}
    }

}
