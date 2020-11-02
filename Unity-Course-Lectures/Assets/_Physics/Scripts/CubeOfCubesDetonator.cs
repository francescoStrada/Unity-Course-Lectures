using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOfCubesDetonator : MonoBehaviour
{
    public float DetonationForce = 5f;
    public float Radius;

    private Rigidbody[] _rigidbodies;

    
    void Start()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Detonate();
    }

    private void Detonate()
    {
        for (int i = 0; i < _rigidbodies.Length; i++)
        {
            _rigidbodies[i].isKinematic = false;
            _rigidbodies[i].AddExplosionForce(DetonationForce, transform.position, Radius);
        }
    }

}
