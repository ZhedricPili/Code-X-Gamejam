using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _playerController;
    [SerializeField]
    float speed;
    void Start()
    {
       _playerController = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));

        _playerController.Move(move * Time.deltaTime * speed);    
    }
}
