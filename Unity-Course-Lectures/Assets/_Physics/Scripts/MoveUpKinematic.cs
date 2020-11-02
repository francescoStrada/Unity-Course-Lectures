using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpKinematic : MonoBehaviour
{
    [SerializeField] private bool _toggleKinematic;
    [SerializeField] private float _speed;

    private Vector3 _originalPosition;
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _originalPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (_rigidbody != null && _toggleKinematic)
                _rigidbody.isKinematic = true;

            
            transform.position = Vector3.MoveTowards(transform.position, _originalPosition, _speed * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.Space))
            if (_rigidbody != null)
                _rigidbody.isKinematic = false;
    }
}
