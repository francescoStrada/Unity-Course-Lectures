using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpKinematic : MonoBehaviour
{
    private Vector3 originalPosition;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (rigidbody != null)
                rigidbody.isKinematic = true;

            transform.position = Vector3.MoveTowards(transform.position, originalPosition, 2f * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.Space))
            if (rigidbody != null)
                rigidbody.isKinematic = false;
    }
}
