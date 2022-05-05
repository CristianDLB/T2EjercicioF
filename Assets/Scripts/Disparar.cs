using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparar : MonoBehaviour
{
    public float velocidad = 8;

    private Rigidbody2D body;

    public static int da�o1;
    public static int da�o2;

    public int refeDa�o = 1;
    public int refeDa�o2 = 2;

    void Start()
    {
        da�o1 = refeDa�o;
        da�o2 = refeDa�o2;

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
