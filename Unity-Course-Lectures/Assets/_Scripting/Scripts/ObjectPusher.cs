using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPusher : Interactable
{
    [SerializeField] private float _pushForce;
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public override void Interact(GameObject caller)
    {
        if (_rigidbody != null)
        {
            _rigidbody.AddForce((transform.position - caller.transform.position).normalized * _pushForce, ForceMode.Impulse);
        }
    
    }
}
