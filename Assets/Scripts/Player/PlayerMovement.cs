using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;

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

    Animator _animator;
    string _currentState;    
    const string playerIdle = "Idle";
    const string playerRun = "Running";



    


    void Start()
    {   
        _playerController = GetComponent<CharacterController>();
        _animator = gameObject.GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementFucntion();
    }
    public void MovementFucntion()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");
        Vector3 _move = new Vector3(xInput,0f,yInput).normalized;
        if (_move.magnitude >= 0.1f)
        {
            float _targetAngle = Mathf.Atan2(_move.x,_move.z) * Mathf.Rad2Deg  + cam.eulerAngles.y;
            float _angle = Mathf.SmoothDampAngle(playerObject.transform.eulerAngles.y,_targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
            playerObject.transform.rotation = Quaternion.Euler(0f, _angle, 0f);

            Vector3 _moveDir = Quaternion.Euler(0f,_targetAngle,0f) * Vector3.forward;
            _playerController.Move(_moveDir.normalized * Time.deltaTime * speed);
        }
        PlayerAnimator(xInput, yInput);
    }
    void PlayerAnimator(float conditionA, float conditionB)
    {
        if(conditionA != 0 || conditionB != 0 )
        {
            ChangeAnimationState(playerRun);
            return;
        }
        ChangeAnimationState(playerIdle);
    }



    void ChangeAnimationState(string newState)
    {
        if(_currentState == newState)
        {
            return;
        }
        _animator.Play(newState);
        _currentState = newState;
    }

}
