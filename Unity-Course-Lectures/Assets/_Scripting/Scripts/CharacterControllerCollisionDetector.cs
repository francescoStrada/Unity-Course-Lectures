using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerCollisionDetector : MonoBehaviour
{

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log($"CharacterController --> OnColliderHit with {hit.gameObject.name}");

    }

}
