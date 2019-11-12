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
        if (Input.GetKey(KeyCode.W))
            transform.Translate(transform.forward * movSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
            transform.Translate(-transform.forward * movSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
            transform.Translate(-transform.right * movSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Translate(transform.right * movSpeed * Time.deltaTime);

    }
}
