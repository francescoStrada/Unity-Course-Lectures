using UnityEngine;
using System.Collections;

public class DeltaTimeMovement : MonoBehaviour
{
    public bool useDeltaTime = true;

    public float speed = 3f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementVector = transform.forward * speed;

        if (useDeltaTime)
            transform.Translate(movementVector * Time.deltaTime);

        else
            transform.Translate(movementVector);

    }
}
