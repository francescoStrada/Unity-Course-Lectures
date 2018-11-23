using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldWest : MonoBehaviour
{
    public Rigidbody shooter0;
    public Rigidbody shooter1;
    public float shootingForce = 3f;

    // 0-> shooter1 - 1-> shooter2
    protected float shooterToKill = 0;

	// Use this for initialization
	void Start ()
    {
		if(shooter0 == null)
            Debug.LogWarning("Shooter0 is missing RigidBody");
        if (shooter1 == null)
            Debug.LogWarning("Shooter1 is missing RigidBody");

        shooterToKill = Random.Range(0f, 1f);

        if(shooterToKill <= 0.5f && shooter0 != null)
        {
            shooter0.isKinematic = false;
            shooter0.AddForce(-shooter0.transform.forward * shootingForce, ForceMode.Impulse);
        }
        else if (shooterToKill > 0.5f && shooter1 != null)
        {
            shooter1.isKinematic = false;
            shooter1.AddForce(-shooter1.transform.forward * shootingForce, ForceMode.Impulse);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
