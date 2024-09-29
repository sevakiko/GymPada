using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerPickup1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other, Player1 player)
    {

        float currentHealth = player.currentHealth;
        if (other.CompareTag("Player1"))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (currentHealth == player.maxHealth)
                {
                    currentHealth -= 10f;
                }
                
            }
        }
    }
}
