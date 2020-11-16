using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Grabbable : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Collider _collider;
    private Transform _originalParent;

    public Transform OriginalParent
    {
        get { return _originalParent; }
        protected set { _originalParent = value; }
    }    
   
    void Start ()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        _originalParent = transform.parent;
		
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
