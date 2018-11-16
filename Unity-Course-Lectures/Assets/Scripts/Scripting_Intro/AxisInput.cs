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
            float yPos = v * range + initialPosition.y;

            transform.position = new Vector3(xPos, yPos, 0);
        }

        else
        {
            float xPos = initialPosition.x;
            float yPos = initialPosition.y;

            if (Input.GetKey(KeyCode.UpArrow))
                yPos = initialPosition.y + range;

            if (Input.GetKey(KeyCode.DownArrow))
                yPos = initialPosition.y - range;

            if (Input.GetKey(KeyCode.LeftArrow))
                xPos = initialPosition.x - range;

            if (Input.GetKey(KeyCode.RightArrow))
                xPos = initialPosition.x + range;


            transform.position = new Vector3(xPos, yPos, 0);
        }
    }
}
