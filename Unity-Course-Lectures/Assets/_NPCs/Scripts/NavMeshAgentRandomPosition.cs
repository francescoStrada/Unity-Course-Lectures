using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class NavMeshAgentRandomPosition : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;

    private NavMeshAgent _navMeshAgent;
    private Renderer _renderer;
    private Color _originalColor;
    private float _totalDistanceToTravel = -1f;

    private bool _arrived = false;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _renderer = GetComponent<Renderer>();
        _originalColor = _renderer.material.color;

        _navMeshAgent.avoidancePriority = Random.Range(0, 32);
        
        SetDestination();
    }

    void Update()
    {
        if( !_arrived && DestinationReached())
            SetDestination();

        if(!_arrived)
            UpdateColor();
    }

    private void UpdateColor()
    {
        if(_totalDistanceToTravel <= 0f)
        {
            _renderer.material.color = _originalColor;
            return;
        }

        if (_navMeshAgent.remainingDistance >= Mathf.Infinity ||
            _navMeshAgent.remainingDistance < 0f ||
            _navMeshAgent.remainingDistance <= Mathf.NegativeInfinity ||
            _navMeshAgent.remainingDistance > _totalDistanceToTravel)
        {
            //During navigation sometimes the remaining distance property might not be accurate, in this case do not update the color of the agent
            return;
        }
        
        float pathCompletePercentage = Mathf.Clamp01(_navMeshAgent.remainingDistance / _totalDistanceToTravel);
        _renderer.material.color = _gradient.Evaluate(pathCompletePercentage);
        
        
    }

    private void SetDestination()
    {
        _navMeshAgent.ResetPath();
        _arrived = false;
        
        NavMeshPath path = new NavMeshPath();
        Vector3 randomPosition = NavAgentSpawner.Instance.GetRandomPositionOnGround();
        
        while (!_navMeshAgent.CalculatePath(randomPosition, path))
        {
            randomPosition = NavAgentSpawner.Instance.GetRandomPositionOnGround();
        }

        _navMeshAgent.SetPath(path);
        StartCoroutine(WaitForPathReady());
    }

    private IEnumerator WaitForPathReady()
    {
        _totalDistanceToTravel = -1f;

        yield return new WaitUntil(() => _navMeshAgent.hasPath);
        yield return new WaitUntil(() => _navMeshAgent.remainingDistance < Mathf.Infinity);

        _totalDistanceToTravel = _navMeshAgent.remainingDistance;
        
    }
    
    private bool DestinationReached()
    {
        if (!_navMeshAgent.pathPending)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _arrived = true;
                return true;
            }
        }

        return false;
    }
}
