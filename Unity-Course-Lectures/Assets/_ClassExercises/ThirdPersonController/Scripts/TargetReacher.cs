using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TargetReacher : MonoBehaviour
{
    public GameObject Character;
    public float MinDistanceToTarget = 0.5f;

    void Start()
    {
        AssignNewPosition();
    }

    void Update()
    {
        if(Character == null)
            return;

        float distanceFromTarget = Vector3.Distance(transform.position, Character.transform.position);
        if (distanceFromTarget <= MinDistanceToTarget)
        {
            AssignNewPosition();
        }
    }

    public void AssignNewPosition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-40f, 40f), 0f, Random.Range(-40f, 40f));
        transform.position = randomPosition;
    }
}
