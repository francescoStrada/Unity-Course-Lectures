using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentRandomPosition : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;

    private NavMeshAgent _navMeshAgent;
    private Renderer _renderer;
    private Color _originalColor;
    private float _currentPathTotalDistance = -1f;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _renderer = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;
        SetDestination();
    }

    void Update()
    {
        if(DestinationReached())
            SetDestination();

        UpdateColor();
    }

    private void UpdateColor()
    {
        if(_currentPathTotalDistance < 0f)
            return;
        float pathCompletePercentage = Mathf.Clamp(_navMeshAgent.remainingDistance / _currentPathTotalDistance, 0, 1);
        _renderer.material.color = _gradient.Evaluate(pathCompletePercentage);
    }

    private void SetDestination()
    {
        NavMeshPath path = new NavMeshPath();
        Vector3 randomPosition = NavAgentSpawner.Instance.GetRandomPositionOnGround();
        
        while (!_navMeshAgent.CalculatePath(randomPosition, path))
        {
            randomPosition = NavAgentSpawner.Instance.GetRandomPositionOnGround();
        }

        _navMeshAgent.SetDestination(randomPosition);
        StartCoroutine(WaitForPathTotalDistance());
    }

    private bool DestinationReached()
    {
        if (!_navMeshAgent.pathPending)
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
                if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude <= 0f)
                    return true;

        return false;
    }

    private IEnumerator WaitForPathTotalDistance()
    {
        _currentPathTotalDistance = -1f;
        _renderer.material.color = _originalColor;
        while (_navMeshAgent.remainingDistance >= Mathf.Infinity || _navMeshAgent.remainingDistance <= 0f)
        {
            yield return null;
        }

        _navMeshAgent.isStopped = false;
        _currentPathTotalDistance = _navMeshAgent.remainingDistance;
    }
}
