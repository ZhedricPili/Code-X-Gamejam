using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
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
        MovementFucntion();
    }
    public void MovementFucntion()
    {
        Vector3 _move = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        _playerController.Move(_move * Time.deltaTime * speed);
    }

}
