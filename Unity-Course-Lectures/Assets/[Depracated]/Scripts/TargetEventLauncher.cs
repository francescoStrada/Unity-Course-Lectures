using System;
using UnityEngine;
using System.Collections;

public class TargetEventLauncher : MonoBehaviour
{
    public Action<Vector3> PlayerReachedTarget;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (PlayerReachedTarget != null)
                PlayerReachedTarget(transform.position);
        }
    }
}
