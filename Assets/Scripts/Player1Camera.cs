using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Camera : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform
    public Vector3 offsetPosition = new Vector3(0.7f, 1.9f, -1.2f); // Constant offset for position
    public Vector3 offsetRotation = new Vector3(0f, 0f, 0f); // Constant offset for rotation (in degrees)

    void LateUpdate()
    {
        // Set the camera position with a constant offset from the player
        transform.position = playerTransform.position + playerTransform.TransformDirection(offsetPosition);
        
        // Apply constant rotation offset
        Quaternion rotationOffset = Quaternion.Euler(offsetRotation);
        transform.rotation = playerTransform.rotation * rotationOffset;
    }
}
