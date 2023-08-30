using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public static WaypointController waypointController;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Transform[] waypoints;
    private int currentWaypoint = 0; 

    void Awake()
    {
        waypointController = this;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        bool isPressed = false;
        Vector2 movement = new Vector2(0, 0);

        if (currentWaypoint < waypoints.Length)
        {
            Transform waypoint = waypoints[currentWaypoint];
                
            if (transform.position.x < waypoint.position.x)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    movement.x = 1;
                    isPressed = true;
                }
            }
            
            if (transform.position.x > waypoint.position.x)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    movement.x = -1;
                    isPressed = true;
                }
            }
            
            if (transform.position.y < waypoint.position.y)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    movement.y = 1;
                    isPressed = true;
                }
            }
            
            if (transform.position.y > waypoint.position.y)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    movement.y = -1;
                    isPressed = true;
                }
            }
                
            movement.Normalize();
            rb.velocity = movement * moveSpeed;

            if (Vector2.Distance(transform.position, waypoint.position) < 0.1f)
            {
                currentWaypoint++;

                if (currentWaypoint == 1)
                {
                    rb.velocity = Vector2.zero;
                    isPressed = false;
                    Debug.Log("Cheguei");
                    LevelMapManager.levelMapManager.OnKey();
                    if (Input.GetKey(KeyCode.E))
                    {
                        LevelMapManager.levelMapManager.ChangeSceneLevel1();
                    }
                }

                if (currentWaypoint == 6)
                {
                    rb.velocity = Vector2.zero;
                    isPressed = false;
                    Debug.Log("Cheguei");
                    LevelMapManager.levelMapManager.OnKey();
                }

                if (currentWaypoint == 11)
                {
                    rb.velocity = Vector2.zero;
                    isPressed = false;
                    Debug.Log("Cheguei");
                    LevelMapManager.levelMapManager.OnKey();
                }

                if (currentWaypoint == waypoints.Length)
                {
                    rb.velocity = Vector2.zero;
                    isPressed = false;
                }
            }
            animator.SetBool("isPressed", isPressed);
        }
    }
}