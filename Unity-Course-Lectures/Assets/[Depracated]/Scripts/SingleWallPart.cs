using UnityEngine;
using System.Collections;

public class SingleWallPart : MonoBehaviour
{
    public Transform explosionPosition;

    private bool explode = false;
    private Rigidbody rb;
    void OnEnable()
    {
        explode = true;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (explode)
        {
            
            rb.AddExplosionForce(30, explosionPosition.position, 5f);

            
        }
    }
    

}
