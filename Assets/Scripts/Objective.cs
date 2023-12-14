using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if(playerInventory != null)
        {
            if (other.CompareTag("Player"))
            {
                playerInventory.ObjectiveCollector();
                gameObject.SetActive(false);
            }

        }
    }
}
