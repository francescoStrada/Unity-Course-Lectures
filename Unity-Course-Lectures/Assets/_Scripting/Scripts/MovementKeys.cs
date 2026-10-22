using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementKeys : MonoBehaviour {

    public float movSpeed = 5;

    // Use this for initialization
    void Start () {
		
	}
	
	void Update ()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null)
            return;

        Vector3 movementVector = Vector3.zero;

        // Legacy Input (as in the videos):
        // if (Input.GetKey(KeyCode.W))
        if (keyboard.wKey.isPressed)
            movementVector += transform.forward;

        // if (Input.GetKey(KeyCode.S))
        if (keyboard.sKey.isPressed)
            movementVector += -transform.forward;

        // if (Input.GetKey(KeyCode.A))
        if (keyboard.aKey.isPressed)
            movementVector += -transform.right;

        // if (Input.GetKey(KeyCode.D))
        if (keyboard.dKey.isPressed)
            movementVector += transform.right;

        transform.Translate(movementVector.normalized * movSpeed * Time.deltaTime, Space.World);

    }
}
