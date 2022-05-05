using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public float velocidad = 8;

    private Rigidbody2D body;

    public static int daño1;
    public static int daño2;

    public int refeDaño = 1;
    public int refeDaño2 = 2;

    void Start()
    {
        daño1 = refeDaño;
        daño2 = refeDaño2;

        body = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 3);
    }


    void Update()
    {
        body.velocity = new Vector2(velocidad, body.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ninja"))
        {
            Destroy(this.gameObject);
        }
    }
}
