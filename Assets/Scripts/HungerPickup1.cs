using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerPickup1 : MonoBehaviour
{
    private void OnTriggerStay(Collider other, Player1 player)
    {

        float currentHealth = player.currentHealth;
        if (other.CompareTag("Player"))
        {

            if(Input.GetKeyDown(KeyCode.E))
            {
                if (currentHealth == player.maxHealth)
                {
                    if (currentHealth >= 0)
                    {
                        currentHealth -= 10f;
                    }
                }
                
            }
        }
    }
}
