using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Grabbable : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Collider _collider;
    
    // Use this for initialization
    void Start ()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Grab(GameObject grabber)
    {
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
    }

    public void Drop()
    {
        _collider.enabled = true;
        _rigidbody.isKinematic = false;
    }
}
