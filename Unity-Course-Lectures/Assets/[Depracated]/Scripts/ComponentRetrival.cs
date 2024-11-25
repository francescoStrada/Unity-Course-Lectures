using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentRetrival : MonoBehaviour {

    protected Rigidbody rb;

    protected float jumpStartTime; // seconds
    protected float timer = 0f;
    

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
            rb.mass = Random.Range(1f, 20);

        jumpStartTime = Random.Range(1f, 4f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if(timer >= jumpStartTime)
        {
            rb.AddForce(Vector3.up * 20f, ForceMode.Impulse);
            
            //Reassign new random variables
            timer = 0;
            jumpStartTime = Random.Range(1f, 4f);
            rb.mass = Random.Range(1f, 20);
        }
		
	}
}
