using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAlongAxis : MonoBehaviour
{
    public float movSpeed = 3f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(transform.forward * movSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-transform.forward * movSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(-transform.right * movSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(transform.right * movSpeed * Time.deltaTime);
    }
}
