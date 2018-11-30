using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterMovement : MonoBehaviour
{
    [SerializeField] private Transform _cameraT;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 3f;

    private Rigidbody _rigidbody;
    private bool _isRigidBodyMovement;
    private Vector3 _inputVector;
    private float _inputSpeed;
    private Vector3 _targetDirection;

    // Use this for initialization
    void Start ()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _isRigidBodyMovement = _rigidbody != null;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Handle the Input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        _inputVector = new Vector3(h, 0, v);
        _inputSpeed = Mathf.Clamp(_inputVector.magnitude, 0f, 1f);

        //Compute direction According to Camera Orientation
        _targetDirection = _cameraT.TransformDirection(_inputVector);
        _targetDirection.y = 0f;

        if (_isRigidBodyMovement)
            return;

        //Update Transform if no rigidbody attached
        Vector3 newDir = Vector3.RotateTowards(transform.forward, _targetDirection, _rotationSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);

        transform.Translate(transform.forward * _inputSpeed * _speed * Time.deltaTime, Space.World);
    }

    private void FixedUpdate()
    {
        //if Rigidbody attached update rigidbody position
        if (!_isRigidBodyMovement)
            return;
        Debug.Log("Rigidbody movement");
        Vector3 newDir = Vector3.RotateTowards(transform.forward, _targetDirection, _rotationSpeed * Time.fixedDeltaTime, 0f);
        _rigidbody.MoveRotation(Quaternion.LookRotation(newDir));

        _rigidbody.MovePosition(_rigidbody.position + transform.forward * _inputSpeed * _speed * Time.fixedDeltaTime);
    }
}
