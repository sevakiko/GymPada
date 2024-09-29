using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class TestInteraction : MonoBehaviour, Interactable1
    {
        [SerializeField] private Vector3 newPlayerPosition;
        [SerializeField] private Quaternion newPlayerRotation;
        [SerializeField] private Vector3 newCameraPosition;
        [SerializeField] private Quaternion newCameraRotation;
        [SerializeField] private int code = 0;

        public int getCode(){
            if(code < 1000){
                return code;
            }
            return code - 1000;
        }

        public void Interact(Player1 player)
        {
            //player.cameraCtrl.GetComponent<Player1Camera>().enabled = false;
            player.setDoingExercise(true);
            player.setExerciseCode(code);

            if(code == 1){
                player.setObjectVisible(0, true);
                player.setObjectVisible(1, true);
            }
            else if(code < 1000){
                player.setObjectVisible(code, true);
            }

            player.transform.position = newPlayerPosition;
            player.transform.rotation = newPlayerRotation;
            player.cameraCtrl.transform.position = newCameraPosition;
            player.cameraCtrl.transform.rotation = newCameraRotation;
        }
    }

