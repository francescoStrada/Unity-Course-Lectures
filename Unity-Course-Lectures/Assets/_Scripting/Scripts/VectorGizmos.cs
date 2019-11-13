using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorGizmos : MonoBehaviour
{
    public bool showLocal = false;
    public bool showGlobal = false;

    public float rayLength = 2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPoint = transform.position + 1.5f * transform.up;

        if (showLocal)
        {
            //UP
            Debug.DrawRay(startPoint, transform.up * rayLength, Color.green);
            //FORWARD
            Debug.DrawRay(startPoint, transform.forward * rayLength, Color.blue);
            //RIGHT
            Debug.DrawRay(startPoint, transform.right * rayLength, Color.red);
        }

        if (showGlobal)
        {
            //UP
            Debug.DrawRay(startPoint, Vector3.up * rayLength, Color.green);
            //FORWARD
            Debug.DrawRay(startPoint, Vector3.forward * rayLength, Color.blue);
            //RIGHT
            Debug.DrawRay(startPoint, Vector3.right * rayLength, Color.red);
        }
    }
}
