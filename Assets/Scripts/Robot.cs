using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{

    public GameObject Bomba1;
    public GameObject Bomba2;

    private Rigidbody2D body;
    private Animator animar;
    private SpriteRenderer render;

    private const int normal = 0;
    private const int correr = 1;
    private const int muerto = 2;
    private const int salto = 3;
    private const int deslizo = 4;
    private const int disparo = 5;

    private float tiempos = 0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animar = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        body.velocity = new Vector2(0, body.velocity.y);
        changeAnimation(normal);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            body.velocity = new Vector2(10, body.velocity.y);
            render.flipX = false;
            changeAnimation(correr);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.velocity = new Vector2(-10, body.velocity.y);
            render.flipX = true;
            changeAnimation(correr);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, 16);
            changeAnimation(salto);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            changeAnimation(deslizo);
        }
        tiempo();

    }

    void tiempo()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            tiempos = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            tiempos = Time.time - tiempos;

            if (tiempos >= 0f)
            {
                changeAnimation(disparo);
                Dsp();
            }
            if (tiempos >= 2f)
            {
                changeAnimation(disparo);
                Dsp2();
            }
        }

    }

    private void Dsp()
    {
        var x = this.transform.position.x;
        var y = this.transform.position.y;

        var Balas = Instantiate(Bomba1, new Vector2(x, y), Quaternion.identity) as GameObject;
        var control = Balas.GetComponent<Disparar>();
    }

    private void Dsp2()
    {
        var x = this.transform.position.x;
        var y = this.transform.position.y;

        var Balas = Instantiate(Bomba2, new Vector2(x, y), Quaternion.identity) as GameObject;
        var control = Balas.GetComponent<Disparar>();

    }



    private void changeAnimation(int animation)
    {
        animar.SetInteger("Estado", animation);
    }
}
