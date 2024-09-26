using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class TestInteraction : MonoBehaviour, Interactable
    {
        public void Interact()
        {
            print(Random.Range(0, 100));
        }
    }

