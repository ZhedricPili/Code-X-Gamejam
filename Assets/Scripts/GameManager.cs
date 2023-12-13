using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    PlayerMovement playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
