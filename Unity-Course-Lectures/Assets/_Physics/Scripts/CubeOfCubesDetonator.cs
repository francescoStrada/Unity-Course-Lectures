using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeOfCubesDetonator : MonoBehaviour
{
    public float detonationForce = 5f;
    public float radius;

    private Rigidbody[] rigidbodies;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Detonate();
    }

    private void Detonate()
    {
        for (int i = 0; i < rigidbodies.Length; i++)
        {
            rigidbodies[i].isKinematic = false;
            rigidbodies[i].AddExplosionForce(detonationForce, transform.position, radius);
        }
    }

}
