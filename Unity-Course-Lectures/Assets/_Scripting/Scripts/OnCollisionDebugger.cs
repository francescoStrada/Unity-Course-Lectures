using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionDebugger : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{gameObject.name} --> OnCollision ENTER with {collision.gameObject.name}");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log($"{gameObject.name} --> OnCollision STAY with {collision.gameObject.name}");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log($"{gameObject.name} --> OnCollision EXIT with {collision.gameObject.name}");
    }
}
