using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform

    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 newPosition = player.position + new Vector3(0, 0, -10);
            newPosition.y = 0.1f;
            transform.position = newPosition;
        }
    }
}
