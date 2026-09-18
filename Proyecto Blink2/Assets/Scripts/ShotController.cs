using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    Collider2D disparandoA = null;
    public float probabilidadDisparo = 1f;
    public GameObject bulletPrototype;
    Player ctr;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Hero") && disparandoA == null)
        {
            DecidaDisparar(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision==disparandoA)
        {
            disparandoA = null;
        }
    }

    void DecidaDisparar(Collider2D collision)
    {
        if (Random.value < probabilidadDisparo)
        {
            Disparar();
            disparandoA = collision;
        }
    }

    void Disparar()
    {
        GameObject bulletCopy = Instantiate(bulletPrototype);
        bulletCopy.transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y,-1);
        bulletCopy.GetComponent<GunController>().direction = new Vector3(-transform.parent.localScale.x, 0, 0);
    }

}


