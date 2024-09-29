using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Camera : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offsetPosition = new Vector3(0.7f, 1.9f, -1.2f);
    public Vector3 offsetRotation = new Vector3(0f, 0f, 0f);
    [SerializeField] Player1 player;

    void LateUpdate()
    {
        if(!player.isDoingExercise){
            transform.position = playerTransform.position + playerTransform.TransformDirection(offsetPosition);
            Quaternion rotationOffset = Quaternion.Euler(offsetRotation);
            transform.rotation = playerTransform.rotation * rotationOffset;
        } 
    }
}
