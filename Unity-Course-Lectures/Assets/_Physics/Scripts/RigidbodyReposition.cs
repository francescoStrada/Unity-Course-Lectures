using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyReposition : MonoBehaviour
{
    public float simulationTime = 3f;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Rigidbody rigidbody;
    private bool isKinematicOriginalState;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        rigidbody = GetComponent<Rigidbody>();

        if (rigidbody != null)
            isKinematicOriginalState = rigidbody.isKinematic;

        InvokeRepeating("RepositionRigibody", 0f, simulationTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RepositionRigibody()
    {
        if(rigidbody != null)
            rigidbody.isKinematic = true;

        transform.position = originalPosition;
        transform.rotation = originalRotation;

        if (rigidbody != null)
            rigidbody.isKinematic = isKinematicOriginalState;
        
    }
}
