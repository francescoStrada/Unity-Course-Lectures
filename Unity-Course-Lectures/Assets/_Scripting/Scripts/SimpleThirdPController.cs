using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleThirdPController : MonoBehaviour
{
    [SerializeField] private Transform _cameraT;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 3f;

    private Vector3 _inputVector;
    private float _inputSpeed;
    private Vector3 _targetDirection;
    
    // Start is called before the first frame update
    void Start()
    {
        
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

        if (_inputSpeed <= 0f)
            return;

        //Calculate rotation vector and rotate
        Vector3 newDir = Vector3.RotateTowards(transform.forward, _targetDirection, _rotationSpeed * Time.deltaTime, 0f);
        transform.rotation = Quaternion.LookRotation(newDir);
        
        //Translate along forward
        transform.Translate(transform.forward * _inputSpeed * _speed * Time.deltaTime, Space.World);
        
        Debug.DrawRay(transform.position + transform.up * 3f, _targetDirection * 5f, Color.red);
        Debug.DrawRay(transform.position + transform.up * 3f, newDir * 5f, Color.blue);
    }
}
