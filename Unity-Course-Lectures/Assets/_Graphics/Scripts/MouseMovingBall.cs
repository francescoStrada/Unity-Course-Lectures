using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MouseMovingBall : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _groundMask;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _groundMask))
        {


            //transform.position = new Vector3(hit.point.x, transform.position.y,hit.point.z);
            _rigidbody.MovePosition(new Vector3(hit.point.x, transform.position.y, hit.point.z));

        }
        
    }
}
