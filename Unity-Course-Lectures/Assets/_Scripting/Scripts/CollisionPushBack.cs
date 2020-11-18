using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPushBack : MonoBehaviour
{
    [SerializeField] private float _repulseForce;

    private Vector3 _pushbackDir;

    
    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;
        if(rb == null)
            return;
        
        Repulse(rb);
    }

    private void Repulse(Rigidbody rb)
    {
        Vector3 repulseDir = rb.transform.position - gameObject.transform.position;
        repulseDir.y = 0f;
        repulseDir.Normalize();

        Debug.DrawRay(transform.position + transform.up * 3f, repulseDir * 5f, Color.green);

        Debug.Log("ADDING FORCE");

        rb.AddForce(repulseDir * _repulseForce, ForceMode.Impulse);
    }

}
