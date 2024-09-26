using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Interactable
{
    public void Interact();
}

public class Player1 : MonoBehaviour
{

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
        
    }

    private float moveSpeed = 0f;
    private Rigidbody rbody;

    [SerializeField] private float moveSpeedForward = 3f;
    [SerializeField] private float moveSpeedBackward = 1.5f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private int interactRange = 2;

    private bool isWalkingForward;
    private bool isWalkingBackward;

    private void Update()
    {
        // forward - backward
        float moveDirection = 0f;
        if (Input.GetKey(KeyCode.W)){
            moveDirection = 1f;
            moveSpeed = moveSpeedForward;
        }
        if (Input.GetKey(KeyCode.S)){ 
            moveDirection = -1f;
            moveSpeed = moveSpeedBackward;
        }

        // left - right rotation
        float rotation = 0f;
        if (Input.GetKey(KeyCode.A)){
            rotation = -1f;
        }
        if (Input.GetKey(KeyCode.D)){
            rotation = 1f;
        }

        // interact
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out Interactable interactObj))
                {
                    print("interact :)");
                    interactObj.Interact();
                }
            }
        }

        isWalkingForward = moveDirection <= 0f? false : true;
        isWalkingBackward = moveDirection >= 0f? false : true;

        
        
        // apply
        if (moveDirection != 0f){
            transform.Translate(Vector3.forward * moveDirection * moveSpeed * Time.deltaTime);
        }

        if (rotation != 0f){
            transform.Rotate(Vector3.up, rotation * rotateSpeed * Time.deltaTime);
        }
    }
    
    public bool IsWalkingForward(){
        return isWalkingForward;
    }

    public bool IsWalkingBackward(){
        return isWalkingBackward;
    }


   



}
