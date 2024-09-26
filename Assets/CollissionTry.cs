using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CollissionTry : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GymObject")
        {
            print("Collided with GymObject");
        }

        if (collision.gameObject.tag == "GymWall")
        {
            print("Collided with GymWall");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "GymObject")
        {
            print("STAY");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "GymObject")
        {
            print("EXIT");
        }
    }




}
