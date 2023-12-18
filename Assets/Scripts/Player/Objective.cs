using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Objective : MonoBehaviour
{

    public GameObject book;


    private void Awake()
    {
        book.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory _playerInventory = other.GetComponent<PlayerInventory>();
        

        if(_playerInventory != null)
        {
            if (other.CompareTag("Player"))
            {
                _playerInventory.ObjectiveCollector();
                Destroy(gameObject);
            }


            

        }
    }


}
