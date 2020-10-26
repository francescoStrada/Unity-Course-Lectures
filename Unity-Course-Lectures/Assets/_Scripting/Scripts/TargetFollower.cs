using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    public GameObject Target;
    public bool SnapToTarget = false;

    public float RotationSpeed = 2f;
    public float MovementSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        //Target not assigned through the inspector
        if(Target == null)
        {
            //Search Target with Tag
            //Target = GameObject.FindGameObjectWithTag("Target");
            
            //Search Target with GameObject Name
            //This method should be avoided
            //Target = GameObject.Find("Target");

            //Search Target GameObject with associated class
            //Finding GameObject with associated scripts is the most robust and secure way
            
            SimpleTarget simpleTarget = GameObject.FindObjectOfType<SimpleTarget>();
            if (simpleTarget != null)
            {
                Target = simpleTarget.gameObject;
            }
            

        }

        //Snap to target is only for demonstration purposes: SnapToTarget should ALWAYS be false
        if(SnapToTarget && Target != null)
            gameObject.transform.position = Target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (SnapToTarget)
            return;

        //Compute target direction
        Vector3 targetDirection = Target.transform.position - transform.position;
        targetDirection.y = 0f;
        targetDirection.Normalize();

        //Rotate toward target direction
        float rotationStep = RotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection, transform.up);

        //Move object along its forward axis
        transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime);
        //IS EQUIVALENT TO 
        //transform.Translate(transform.forward * MovementSpeed * Time.deltaTime, Space.World);
    }

}
