using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidade de movimento do boneco
    private Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        bool isPressed = false;

        // Botão W
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Botão W pressionado.");
            isPressed = true;
        }

        // Botão A
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Botão A pressionado");
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            isPressed = true;
        }

        // Botão S
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Botão S pressionado.");
            isPressed = true;
        }
        
        // Botão D
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Botão D pressionado.");
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            isPressed = true;
        }

        animator.SetBool("isPressed", isPressed);
    }
}
