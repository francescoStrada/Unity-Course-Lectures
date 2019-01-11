using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ColliderEventDispatcher : MonoBehaviour
{
    public Action<Collider> TriggerEnter;
    public Action<Collision> CollisionEnter;

    public void OnTriggerEnter(Collider other)
    {
        if (TriggerEnter != null)
            TriggerEnter(other);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (CollisionEnter != null)
            CollisionEnter(collision);
    }
}
