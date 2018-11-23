using UnityEngine;
using System.Collections;

public class AxisInput : MonoBehaviour
{
    public float range = 2.0f;
    public bool axisInput = true;

    private Vector3 initialPosition;
    // Use this for initialization
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (axisInput)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            float xPos = h * range + initialPosition.x;
            float zPos = v * range + initialPosition.z;

            transform.position = new Vector3(xPos, initialPosition.y, zPos);
        }

        else
        {
            float xPos = initialPosition.x;
            float zPos = initialPosition.z;

            if (Input.GetKey(KeyCode.W))
                zPos = initialPosition.z + range;

            if (Input.GetKey(KeyCode.S))
                zPos = initialPosition.z - range;

            if (Input.GetKey(KeyCode.A))
                xPos = initialPosition.x - range;

            if (Input.GetKey(KeyCode.D))
                xPos = initialPosition.x + range;


            transform.position = new Vector3(xPos, initialPosition.y, zPos);
        }
    }
}
