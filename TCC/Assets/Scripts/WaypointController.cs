using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public static WaypointController waypointController;
    public bool isPressed = false;
    public bool isOnLevel = false;
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
        isPressed = false;
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
            
            float distanceToWaypoint = Vector2.Distance(transform.position, waypoint.position);

            if (distanceToWaypoint < 0.1f)
            {
                currentWaypoint++;

                Debug.Log(currentWaypoint);

                if (currentWaypoint == 1 || currentWaypoint == 6 || currentWaypoint == 11)
                {
                    if (!isOnLevel)
                    {
                        isOnLevel = true;
                        LevelMapManager.levelMapManager.OnKey();
                    }
                }
                else
                {
                    if (isOnLevel)
                    {
                        isOnLevel = false;
                        LevelMapManager.levelMapManager.OutKey();
                    }
                }

                if (currentWaypoint == waypoints.Length)
                {
                    rb.velocity = Vector2.zero;
                    isPressed = false;
                }

                Debug.Log(PlayerPrefs.GetInt("Levels"));
                Debug.Log(isOnLevel);
            }
        }

        if (isOnLevel == true && Input.GetKey(KeyCode.E))
        {
            LevelMapManager.levelMapManager.ChangeSceneLevel(currentWaypoint);
        }

        animator.SetBool("isPressed", isPressed);
    }
}