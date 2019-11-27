using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollisionDetecter : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        CollisionColorChanger colorChanger = collision.gameObject.GetComponent<CollisionColorChanger>();
        Rigidbody collisionRigidBody = collision.gameObject.GetComponent<Rigidbody>();

        if (colorChanger != null && collisionRigidBody == null)
            StartCoroutine(colorChanger.Blink());
    }

}
