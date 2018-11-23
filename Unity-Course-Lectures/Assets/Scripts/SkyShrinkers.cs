using UnityEngine;
using System.Collections;

public class SkyShrinkers : MonoBehaviour
{
    private FPSInteractionManager interactionManager;

    void Start()
    {
        interactionManager = FindObjectOfType<FPSInteractionManager>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            interactionManager.InteractionDistance = 40f;
            Rigidbody[] rigidbodies = transform.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody r in rigidbodies)
            {
                r.useGravity = true;
            }
        }
    }
}
