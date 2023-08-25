using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    // public GameObject leve1, level2, level3, level4, level5, level6;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bool isPressed = false;
        Vector2 movement = new Vector2(0, 0);

<<<<<<< HEAD
        Transform waypoint = waypoints[nextWaypoint];

        // Horizontal Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        movement.x = horizontalInput;
        isPressed = Mathf.Abs(horizontalInput) > 0.1f;

        // Vertical Movement
        float verticalInput = Input.GetAxis("Vertical");
        movement.y = verticalInput;
        isPressed |= Mathf.Abs(verticalInput) > 0.1f;

        movement.Normalize();
        rb.velocity = movement * moveSpeed;

        if (Vector2.Distance(transform.position, waypoint.position) < 0.1f)
        {
            nextWaypoint++;
            if (nextWaypoint >= waypoints.Length)
            {
                nextWaypoint = 0;
            }
        }

=======
        // Botão W
        if (Input.GetKey(KeyCode.W))
        {
            movement.y = 1;
            isPressed = true;
            Debug.Log("Botão W pressionado.");
        }

        // Botão A
        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            isPressed = true;
            Debug.Log("Botão A pressionado");
        }

        // Botão S
        if (Input.GetKey(KeyCode.S))
        {
            movement.y = -1;
            isPressed = true;
            Debug.Log("Botão S pressionado.");
        }
        
        // Botão D
        if (Input.GetKey(KeyCode.D))
        {
            movement.x = 1;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            isPressed = true;
            Debug.Log("Botão D pressionado.");
        }
        
        movement.Normalize();
        rb.velocity = movement * moveSpeed;

>>>>>>> 5d40ea21d4b2c0e6266548770959dd9024cee129
        animator.SetBool("isPressed", isPressed);
    }
}
