using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public static Player player;
    public float vel = -1f;
    Rigidbody2D rgb;
    Animator anim;
    bool right = true;
    bool caminando = false;
    bool shooting = false;

    bool canJump = false;
    bool doubleJump = false;
    bool isDoubleJump = false;
    bool isAlive = true;

    bool inTheEarth = false;

    public Slider slider;
    public Text text;

    public float velScale = 5;
    public float gunDamage = 5;
    public float topDamage = 5;
    public float endDamage = 10;
    
    public float forceDamage = 20000;

    AudioSource aSource;
    public AudioClip jumping;
    public AudioClip damaging;
    public AudioClip dying;

    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        player = this;
        rgb = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        aSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        Jump();
    }


    void FixedUpdate()
    {
        Mov();
    }

    void Mov() 
    {
        float v = Input.GetAxis("Horizontal");
        Vector2 vel = new Vector2(0, rgb.velocity.y);
        v *= velScale;
        vel.x = v;
        rgb.velocity = vel;

        if (right && v < 0)
        {
            right = false;
            Flip();
        }
        else if (!right && v > 0)
        {
            right = true;
            Flip();
        }
        
        if (rgb.velocity.x == 0)
        {
            if (!(rgb.velocity.y > 0.05 || rgb.velocity.y < -0.05))
            {
                gameObject.GetComponent<Animator>().SetBool("stop", true);
                gameObject.GetComponent<Animator>().SetBool("caminando", false);
                //anim.SetTrigger("stop");
                caminando = false;
            }
        }
        else if (!(rgb.velocity.x == 0) && !caminando){
            if (!(rgb.velocity.y > 0.05 || rgb.velocity.y < -0.05))
            {
                gameObject.GetComponent<Animator>().SetBool("stop", false);
                gameObject.GetComponent<Animator>().SetBool("caminando", true);
                caminando = true;
                //anim.SetTrigger("caminando");
            }
        }
    }
    
    void Flip()
    {
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }

    void Shoot() 
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            gameObject.GetComponent<Animator>().SetBool("shooting", true);
            Action();
        }
        
    }

    void Action() 
    {
        if (rgb.velocity.x != 0)
        {
            if(!(rgb.velocity.y > 0.1 || rgb.velocity.y < -0.1))
            {
                gameObject.GetComponent<Animator>().SetBool("caminando", true);
            }
            
        }
        else 
        {
            if (!(rgb.velocity.y > 0.1 || rgb.velocity.y < -0.1))
            {
                gameObject.GetComponent<Animator>().SetBool("stop", true);
            }
        }
    }

    void Jump()
    {
        
        /*if ((rgb.velocity.y > 0.1 || rgb.velocity.y < -0.1))
        {
            gameObject.GetComponent<Animator>().SetBool("saltando", true);
        }*/
        Vector2 vel = new Vector2(rgb.velocity.x, rgb.velocity.y);
        vel.y = velScale;
        if((Input.GetKeyDown("up") || Input.GetKeyDown("w")) && canJump)
        {
            canJump = false;
            aSource.PlayOneShot(jumping);
            rgb.velocity = vel;
            gameObject.GetComponent<Animator>().SetBool("saltando", true);
        }
        if ((Input.GetKeyDown("up") || Input.GetKeyDown("w")) && doubleJump)
        {
            canJump = false;
            aSource.PlayOneShot(jumping);
            rgb.velocity = vel;
            doubleJump = false;
            gameObject.GetComponent<Animator>().SetBool("saltando", true);
        }
        rgb.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Death()
    {
        if (slider.value <= 0 && isAlive) 
        {

            //aSource.PlayOneShot(dying);
            isAlive = false;
            gameObject.GetComponent<Animator>().SetBool("color2", true);
        }
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Grownd")
        {
            //canJump = false;
            if (isDoubleJump)
            {
                doubleJump = true;
            }
            
        }               
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Grownd")
        {
            doubleJump = false;
            canJump = true;

            if ((rgb.velocity.x > 0 || rgb.velocity.x < -0.01))
            {
                gameObject.GetComponent<Animator>().SetBool("caminando", true);
                caminando = true;
            }
        }
        if (collision.transform.tag == "GunLevel1")
        {
            HeroDamage(gunDamage);
        }
        if (collision.transform.tag == "EnemyTopBad")
        {
            Vector2 vel = new Vector2(rgb.velocity.x, rgb.velocity.y);
            vel.y = 3f;
            rgb.velocity = vel;
            HeroDamage(topDamage);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "EnemyTop")
        {
            Vector2 vel = new Vector2(rgb.velocity.x, rgb.velocity.y);
            vel.y = 1f;
            rgb.velocity = vel;
        }

        if (collision.transform.tag == "EnemyTopBad")
        {
            Vector2 vel = new Vector2(rgb.velocity.x, rgb.velocity.y);
            vel.y = 3f;
            rgb.velocity = vel;
            HeroDamage(topDamage);
        }

        if (collision.transform.tag == "EnemyRightBad")
        {
            HeroDamage(topDamage);
        }

        if (collision.transform.tag == "EnemyLeftBad")
        {
            HeroDamage(topDamage);
        }

        if (collision.transform.tag == "EnemyBottomBad")
        {
            HeroDamage(topDamage);
        }
    }

    public void HeroDamage(float damage)
    {
        LifeManager.lifeManager.LowerLife(damage);
        gameObject.GetComponent<Animator>().SetBool("color2", true);
        aSource.PlayOneShot(damaging);
        Death();
    }

    public void HeroAction(float damage)
    {
        LifeManager.lifeManager.LowerLife(damage);
        Death();
    }

    public void Teleport(float x,float y, float z)
    {
        gameObject.transform.position = new Vector3(x, y, z);        
    }


}
