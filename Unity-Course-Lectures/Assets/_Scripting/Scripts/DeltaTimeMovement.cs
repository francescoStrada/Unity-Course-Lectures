using UnityEngine;
using System.Collections;

public class DeltaTimeMovement : MonoBehaviour
{
    public bool UseDeltaTime = true;

    public float Speed = 3f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementVector = transform.forward * Speed;

        if (UseDeltaTime)
            transform.Translate(movementVector * Time.deltaTime);

        else
            transform.Translate(movementVector);

    }
}
