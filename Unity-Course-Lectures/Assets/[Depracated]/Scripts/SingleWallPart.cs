using UnityEngine;
using System.Collections;

public class SingleWallPart : MonoBehaviour
{
    public Transform explosionPosition;

    private bool explode = false;
    private Rigidbody rigidbody;
    void OnEnable()
    {
        explode = true;
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (explode)
        {
            
            rigidbody.AddExplosionForce(30, explosionPosition.position, 5f);

            
        }
    }
    

}
