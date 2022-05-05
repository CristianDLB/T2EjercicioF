using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaEnemigo : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animar;
    private SpriteRenderer render;

    public int Vida1 = 3;
    public int Vida2 = 4;

    public static int da�os;
    public int refeDa�o = 1;

    public static int da�os2;
    public int refeDa�o2 = 2;

    private const int correr = 0;

    void Start()
    {
        da�os = refeDa�o;
        da�os2 = refeDa�o2;

        body = GetComponent<Rigidbody2D>();
        animar = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (render.flipX == false)
        {
            body.velocity = new Vector2(8, body.velocity.y);
            changeAnimation(correr);
        }
        if (render.flipX == true)
        {
            body.velocity = new Vector2(-8, body.velocity.y);
            changeAnimation(correr);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("bala1"))
    //    {
    //        Vida1 -= Disparar.da�o1;
    //        Debug.Log("Tengo Menos Vida");
    //        if (Vida1 <= 0)
    //        {
    //            Destroy(this.gameObject);
    //            Debug.Log("Muerto");
    //        }

    //    }

    //    if (collision.gameObject.CompareTag("bala2"))
    //    {
    //        Vida1 -= Disparar.da�o2;
    //        Debug.Log("Tengo Menos Vida");
    //        if (Vida1 <= 0)
    //        {
    //            Destroy(this.gameObject);
    //            Debug.Log("Muerto");
    //        }

    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ch1"))
        {
            render.flipX = true;
            changeAnimation(correr);
        }
        if (collision.gameObject.CompareTag("ch2"))
        {
            render.flipX = false;
            changeAnimation(correr);
        }


        if (collision.gameObject.CompareTag("bala1"))
        {
            Vida1 -= Disparar.da�o1;
            Debug.Log("Tengo Menos Vida");
            if (Vida1 <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Muerto");
            }

        }

        if (collision.gameObject.CompareTag("bala2"))
        {
            Vida1 -= Disparar.da�o2;
            Debug.Log("Tengo Menos Vida");
            if (Vida1 <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Muerto");
            }

        }
    }

    private void changeAnimation(int animation)
    {
        animar.SetInteger("Est", animation);
    }
}
