using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class MovingTarget : Target
{
    public float movSpeed = 3f;
    public float distanceSpanning = 10f;

    protected Vector3[] _pointsToReach = new Vector3[2];
    protected int _indexToReach = 0;
    protected Vector3 _currentPointToReach, _movDirection;
    protected bool _targetReached = false;

    // Use this for initialization
    void Start()
    {
        _pointsToReach[0] = transform.localPosition + transform.right * distanceSpanning;
        _pointsToReach[1] = transform.localPosition - transform.right * distanceSpanning;
        _currentPointToReach = _pointsToReach[_indexToReach];

    }

    
    void Update()
    {
        //_movDirection = _currentPointToReach - transform.position;
        //transform.Translate(_movDirection.normalized * movSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, _currentPointToReach, movSpeed * Time.deltaTime);

        if (TargetReached(_currentPointToReach, 0.00001f))
        {

            _indexToReach = (_indexToReach + 1) % _pointsToReach.Length;
            _currentPointToReach = _pointsToReach[_indexToReach];
        }

    }

    protected bool TargetReached(Vector3 target, float minDistanceToTarget)
    {
        float distanceSquared = (transform.position - target).sqrMagnitude;
        return (distanceSquared <= minDistanceToTarget * minDistanceToTarget);
    }
}
