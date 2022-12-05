using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    //Set the rotation speed for the camera.
    [SerializeField] private float speed;
    // Assign the player who the camera is going to follow.
    public GameObject player;

    void Update()
    {
        // Get the horizontal axis.
        float horizontalInput = Input.GetAxis("Horizontal");
        // Set the rotate function to camera
        transform.Rotate(Vector3.up, horizontalInput * speed * Time.deltaTime);
        // Move focal point with player
        transform.position = player.transform.position; 

    }
}
