using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReacher : MonoBehaviour
{
    public GameObject TargetPrefab;
    public float MinDistanceToTarget = 0.5f;

    private GameObject _currentTarget;
    
    void Start()
    {
        CreateNewTarget();
    }

    void Update()
    {
        if(_currentTarget == null)
            return;

        float distanceFromTarget = Vector3.Distance(transform.position, _currentTarget.transform.position);
        if (distanceFromTarget <= MinDistanceToTarget)
        {
            DestroyCurrentTarget();
            CreateNewTarget();
        }
    }

    public void CreateNewTarget()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-40f, 40f), 0f, Random.Range(-40f, 40f));
        _currentTarget = Instantiate(TargetPrefab);
        _currentTarget.transform.position = randomPosition;

    }

    public void DestroyCurrentTarget()
    {
        Destroy(_currentTarget);
    }
}
