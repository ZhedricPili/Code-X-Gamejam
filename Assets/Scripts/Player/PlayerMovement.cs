using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController _playerController;
    [Tooltip("How fast player go brrrr")]
    [SerializeField] 
    public float speed;
    public GameObject playerObject;
    public Transform cam;
    public float turnSmoothTime = 0.1f;

    private float _turnSmoothVelocity;

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
        Vector3 _move = new Vector3(Input.GetAxisRaw("Horizontal"),0f,Input.GetAxisRaw("Vertical")).normalized;
        if (_move.magnitude >= 0.1f)
        {
            float _targetAngle = Mathf.Atan2(_move.x,_move.z) * Mathf.Rad2Deg  + cam.eulerAngles.y;
            float _angle = Mathf.SmoothDampAngle(playerObject.transform.eulerAngles.y,_targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
            playerObject.transform.rotation = Quaternion.Euler(0f, _angle, 0f);

            Vector3 _moveDir = Quaternion.Euler(0f,_targetAngle,0f) * Vector3.forward;
            _playerController.Move(_moveDir.normalized * Time.deltaTime * speed);   
        }
    }

}
