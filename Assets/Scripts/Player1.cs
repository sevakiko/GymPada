using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface Interactable
{
    int getCode();
    void Interact(Player1 player);
}

public class Player1 : MonoBehaviour
{
    private string[] exerciseText = {"Bicep Curl"};

    private float moveSpeed = 0f;

    [SerializeField] private float progress = 0f;
    [SerializeField] private int exerciseCode = -1;
    [SerializeField] private float moveSpeedForward = 3f;
    [SerializeField] private float moveSpeedBackward = 1.5f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private int interactRange = 2;
    [SerializeField] private GameObject[] objects;
    [SerializeField] public Camera cameraCtrl;
    private Animator animator;

    private bool isWalkingForward;
    private bool isWalkingBackward;
    private bool isDoingExercise = false;

    private Vector3 tmpPosition;
    private Quaternion tmpRotation;
    private int tmpCode;

    public float maxHealth = 100;
    public float currentHealth;
    public HealthBar healthBar;

    public float maxProgress = 100;
    public float currentProgress;
    public ProgressBar progressBar;

    private void Start() {
        animator = GetComponent<Animator>();
        foreach(GameObject go in objects){
            go.SetActive(false);
        }
    }

    private void Update()
    {
        float moveDirection = 0f;
        float rotation = 0f;

        // handle exercise
        if(isDoingExercise){

            if (Input.GetKeyDown(KeyCode.Space)){
                progress += 10f;
            }

            if(progress > 0.2){
                progress = progress - 0.2f;
            }

            if (Input.GetKeyDown(KeyCode.E)){
                progress = 0;
                exerciseCode = 0;
                transform.position = tmpPosition;
                //setObjectVisible(tmpCode, false);
                cameraCtrl.GetComponent<Player1Camera>().enabled = true;
                isDoingExercise = false;
                animator.SetTrigger("Idle");
            }

            return;
        }

        // movement forward - backward
        if (Input.GetKey(KeyCode.W)){
            moveDirection = 1f;
            moveSpeed = moveSpeedForward;
        }
        if (Input.GetKey(KeyCode.S)){
            moveDirection = -1f;
            moveSpeed = moveSpeedBackward;
        }

        // rotation left - right
        if (Input.GetKey(KeyCode.A)){
            rotation = -1f;
        }
        if (Input.GetKey(KeyCode.D)){
            rotation = 1f;
        }

        // interact
        if (Input.GetKeyDown(KeyCode.E)){
            Ray r = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out Interactable interactObj))
                {
                    tmpPosition = transform.position;
                    tmpRotation = transform.rotation;
                    tmpCode = interactObj.getCode();
                    animator.SetTrigger(exerciseText[tmpCode]);
                    interactObj.Interact(this);
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

        //Debug.Log(currentHealth);
        //Debug.Log(currentProgress);
        if (currentHealth >= 0)
        {
            currentHealth -= 1f * Time.deltaTime;
            healthBar.SetHealth(currentHealth);
        }
    }

    public bool IsWalkingForward(){
        return isWalkingForward;
    }

    public bool IsWalkingBackward(){
        return isWalkingBackward;
    }

    public void setDoingExercise(bool set){
        isDoingExercise = set;
    }

    public void setObjectVisible(int idx, bool set){
        objects[idx].SetActive(set);
    }

    public void setExerciseCode(int code){
        exerciseCode = code;
    }

}
