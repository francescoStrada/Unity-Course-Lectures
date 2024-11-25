using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyReposition : MonoBehaviour
{
    public float simulationTime = 3f;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private Rigidbody rb;
    private bool isKinematicOriginalState;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        rb = GetComponent<Rigidbody>();

        if (rb != null)
            isKinematicOriginalState = rb.isKinematic;

        if(simulationTime > 1f)
            InvokeRepeating("RepositionRigibody", 0f, simulationTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            RepositionRigibody();
    }

    private void RepositionRigibody()
    {
        if(rb != null)
            rb.isKinematic = true;

        transform.position = originalPosition;
        transform.rotation = originalRotation;

        if (rb != null)
            rb.isKinematic = isKinematicOriginalState;
        
    }
}
