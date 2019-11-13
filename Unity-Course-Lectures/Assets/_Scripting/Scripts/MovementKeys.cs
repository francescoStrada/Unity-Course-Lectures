using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementKeys : MonoBehaviour {

    public float movSpeed = 5;

    // Use this for initialization
    void Start () {
		
	}
	
	void Update ()
    {
        Vector3 movementVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            movementVector += transform.forward;

        if (Input.GetKey(KeyCode.S))
            movementVector += -transform.forward;

        if (Input.GetKey(KeyCode.A))
            movementVector += -transform.right;

        if (Input.GetKey(KeyCode.D))
            movementVector += transform.right;

        transform.Translate(movementVector.normalized * movSpeed * Time.deltaTime, Space.World);

    }
}
