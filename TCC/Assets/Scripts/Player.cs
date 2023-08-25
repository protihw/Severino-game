using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Transform[] waypoints;
    private int nextWaypoint = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bool isPressed = false;
        Vector2 movement = new Vector2(0, 0);

        Transform waypoint = waypoints[nextWaypoint];

        if (transform.position.x < waypoint.position.x)
        {
            // Botão D
            if (Input.GetKey(KeyCode.D))
            {
                movement.x = 1;
                isPressed = true;
                Debug.Log("Botão D pressionado.");
                if (Input.GetKey(KeyCode.A))
                {
                    movement.x = -1;
                    isPressed = true;
                    Debug.Log("Botão A pressionado");
                }
            }
        }

        if (transform.position.x > waypoint.position.x)
        {
            // Botão A
            if (Input.GetKey(KeyCode.A))
            {
                movement.x = -1;
                isPressed = true;
                Debug.Log("Botão A pressionado");
                if (Input.GetKey(KeyCode.D))
                {
                    movement.x = 1;
                    isPressed = true;
                    Debug.Log("Botão D pressionado.");
                }
            }
        }

        if (transform.position.y < waypoint.position.y)
        {
            // Botão W
            if (Input.GetKey(KeyCode.W))
            {
                movement.y = 1;
                isPressed = true;
                Debug.Log("Botão W pressionado.");
                if (Input.GetKey(KeyCode.S))
                {
                    movement.y = -1;
                    isPressed = true;
                    Debug.Log("Botão S pressionado.");
                }
            }
        }

        if (transform.position.y > waypoint.position.y)
        {
            // Botão S
            if (Input.GetKey(KeyCode.S))
            {
                movement.y = -1;
                isPressed = true;
                Debug.Log("Botão S pressionado.");
                if (Input.GetKey(KeyCode.W))
                {
                    movement.y = 1;
                    isPressed = true;
                    Debug.Log("Botão W pressionado.");
                }
            }
        }

        movement.Normalize();
        rb.velocity = movement * moveSpeed;

        if (Vector2.Distance(transform.position, waypoint.position) < 0.1f)
        {
            nextWaypoint++;
        }

        if (Vector2.Distance(Transform.positionm, waypoint.position) > 0.1f)
        {
            nextWaypoint--;
        }

        animator.SetBool("isPressed", isPressed);
    }
}