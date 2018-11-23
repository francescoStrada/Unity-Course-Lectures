using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidBodyMoveAlongAxis : MonoBehaviour
{
    public float movSpeed = 10;
    protected Rigidbody _rigidbody;


	// Use this for initialization
	void Start ()
    {
        _rigidbody = GetComponent<Rigidbody>();
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            _rigidbody.MovePosition(transform.position + transform.forward * movSpeed * Time.fixedDeltaTime);
                
        if (Input.GetKey(KeyCode.DownArrow))
            _rigidbody.MovePosition(transform.position - transform.forward * movSpeed * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            _rigidbody.MovePosition(transform.position - transform.right * movSpeed * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            _rigidbody.MovePosition(transform.position + transform.right * movSpeed * Time.fixedDeltaTime);

        _rigidbody.angularVelocity = Vector3.zero;

    }
}
