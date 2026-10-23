using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleThirdPRigidbodyController : MonoBehaviour
{
    [SerializeField] private Transform _cameraT;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 3f;
    [SerializeField] private InputActionReference _moveAction;

    private Rigidbody _rigidbody;
    private Vector3 _inputVector;
    private float _inputSpeed;
    private Vector3 _targetDirection;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        // Project-wide actions are shared by every script, so they are enabled here but never disabled
        _moveAction.action.Enable();
    }

    void Update()
    {
        //Handle the Input
        // Legacy Input (as in the videos):
        // float h = Input.GetAxis("Horizontal");
        // float v = Input.GetAxis("Vertical");
        Vector2 moveInput = _moveAction.action.ReadValue<Vector2>();
        float h = moveInput.x;
        float v = moveInput.y;
        _inputVector = new Vector3(h, 0, v);
        _inputSpeed = Mathf.Clamp(_inputVector.magnitude, 0f, 1f);

        //Compute direction According to Camera Orientation
        _targetDirection = _cameraT.TransformDirection(_inputVector).normalized;
        _targetDirection.y = 0f;
    }

    private void FixedUpdate()
    {
        Vector3 newDir = Vector3.RotateTowards(transform.forward, _targetDirection, _rotationSpeed * Time.fixedDeltaTime, 0f);
        
        Debug.DrawRay(transform.position + transform.up * 3f, _targetDirection * 5f, Color.red);
        Debug.DrawRay(transform.position + transform.up * 3f, newDir * 5f, Color.blue);

        _rigidbody.MoveRotation(Quaternion.LookRotation(newDir));
        _rigidbody.MovePosition(_rigidbody.position + transform.forward * _inputSpeed * _speed * Time.fixedDeltaTime);
    }

    
}
