using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public float movSpeed = 4f;

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Target");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Compute target direction
        Vector3 targetDirection = target.transform.position - transform.position;
        targetDirection.y = 0f;
        targetDirection.Normalize();

        //Rotate toward target direction
        float rotationStep = rotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection, transform.up);

        //Move object along its forward axis
        transform.Translate(Vector3.forward * movSpeed * Time.deltaTime);
        //IS EQUIVALENT TO 
        //transform.Translate(transform.forward * movSpeed * Time.deltaTime, Space.World);
    }

}
