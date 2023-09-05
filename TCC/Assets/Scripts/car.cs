using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class car : MonoBehaviour
{
    public Vector3 posicaoinicial;
    public Rigidbody2D carbody;
    public float velocidade;
    void Start()
    {
        posicaoinicial= transform.position;
    }

    void FixedUpdate()
    {
        carbody.velocity= new Vector2 (velocidade,0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("fim"))
        {
            transform.position = posicaoinicial;
        }
    }

}
