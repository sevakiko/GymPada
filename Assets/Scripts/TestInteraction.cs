using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class TestInteraction : MonoBehaviour, Interactable
    {
        [SerializeField] private Vector3 newPlayerPosition = new Vector3(10, 10, 10);
        [SerializeField] private Quaternion newPlayerRotation = new Quaternion(0, 0, 0, 0);
        [SerializeField] private Vector3 newCameraPosition = new Vector3(10, 10, 10);
        [SerializeField] private Quaternion newCameraRotation = new Quaternion(0, 0, 0, 0);
        [SerializeField] private int code = 0;

        public int getCode(){
            return code;
        }

        public void Interact(Player1 player)
        {
            //player.cameraCtrl.GetComponent<Player1Camera>().enabled = false;
            player.setDoingExercise(true);
            player.setExerciseCode(code);
            //player.setObjectVisible(code, true);
            player.transform.position = newPlayerPosition;
            player.transform.rotation = newPlayerRotation;
            //player.cameraCtrl.transform.position = newCameraPosition;
            //player.cameraCtrl.transform.rotation = newCameraRotation;
        }
    }

