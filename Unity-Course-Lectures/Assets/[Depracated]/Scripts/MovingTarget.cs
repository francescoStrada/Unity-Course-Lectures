using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class MovingTarget : MonoBehaviour
{
    public float movSpeed = 3f;
    public float distanceSpanning = 10f;
    public bool hideOnStart = false;

    protected Vector3[] _pointsToReach = new Vector3[2];
    protected int _indexToReach = 0;
    protected Vector3 _currentPointToReach, _movDirection;
    protected bool _targetReached = false;

    void Start()
    {
        _pointsToReach[0] = transform.localPosition + transform.right * distanceSpanning;
        _pointsToReach[1] = transform.localPosition - transform.right * distanceSpanning;
        _currentPointToReach = _pointsToReach[_indexToReach];

        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (renderer != null)
            renderer.enabled = !hideOnStart;

    }

    
    void Update()
    {
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
