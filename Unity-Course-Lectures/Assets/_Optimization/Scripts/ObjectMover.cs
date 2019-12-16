using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private Vector3 _movementVector;
    [SerializeField] private float _speed;
    [SerializeField] private float _stoppingTime;

    private Vector3 _originalPosition;
    private Vector3 _destination;
    private Vector3 _currentMovementVector;

    private bool isWaiting = false;

    // Start is called before the first frame update
    void Start()
    {
        _originalPosition = transform.position;
        _currentMovementVector = -_movementVector;
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _destination, _speed * Time.deltaTime);

        if (!isWaiting && (_destination - transform.position).sqrMagnitude < Mathf.Epsilon)
        {
            StartCoroutine(WaitCoroutine());
        }
    }

    private IEnumerator WaitCoroutine()
    {
        isWaiting = true;

        yield return new WaitForSeconds(_stoppingTime);
        UpdateDestination();
        isWaiting = false;
    }

    private void UpdateDestination()
    {
        _currentMovementVector = -_currentMovementVector;
        float xDestination = (_originalPosition + transform.right * _currentMovementVector.x).x;
        float zDestination = (_originalPosition + transform.forward * _currentMovementVector.z).z;
        float yDestination = _originalPosition.y;

        _destination = new Vector3(xDestination, yDestination, zDestination);
    }
}
