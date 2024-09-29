using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerPickup : MonoBehaviour
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
                    if (currentHealth < 100)
                    {
                        currentHealth += 20f;
                    }
                }
                
            }
        }
    }
}
