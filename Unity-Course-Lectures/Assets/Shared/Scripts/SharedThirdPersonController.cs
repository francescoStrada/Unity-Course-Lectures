using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedThirdPersonController : MonoBehaviour
{
    [SerializeField] private Transform _cameraT;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 3f;

    private Rigidbody _rigidbody;
    private Vector3 _inputVector;
    private float _inputSpeed;
    private float _previousFrameSpeed;
    private Vector3 _targetDirection;

    private bool _resetVelocity;

    // Use this for initialization
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Handle the Input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        _inputVector = new Vector3(h, 0, v);
        _inputSpeed = Mathf.Clamp(_inputVector.magnitude, 0f, 1f);



        //Compute direction According to Camera Orientation
        _targetDirection = _cameraT.TransformDirection(_inputVector).normalized;
        _targetDirection.y = 0f;

        if (_previousFrameSpeed > 0f && _inputSpeed <= 0f)
            _resetVelocity = true;

        _previousFrameSpeed = _inputSpeed;
    }

    private void FixedUpdate()
    {

        Vector3 newDir = Vector3.RotateTowards(transform.forward, _targetDirection, _rotationSpeed * Time.fixedDeltaTime, 0f);
        Debug.DrawRay(transform.position + transform.up * 3f, _targetDirection * 5f, Color.red);
        Debug.DrawRay(transform.position + transform.up * 3f, newDir * 5f, Color.blue);

        if (_resetVelocity)
        {
            _rigidbody.linearVelocity = Vector3.zero;
            _resetVelocity = false;
        }


        _rigidbody.MoveRotation(Quaternion.LookRotation(newDir));
        _rigidbody.MovePosition(_rigidbody.position + transform.forward * _inputSpeed * _speed * Time.fixedDeltaTime);
    }
}
