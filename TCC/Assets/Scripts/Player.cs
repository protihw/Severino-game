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

        animator.SetBool("isPressed", isPressed);
    }
}
