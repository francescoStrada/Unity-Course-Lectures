using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterNavControllerCheckPath : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _targetFeedback;
    [SerializeField] private bool _checkPath = true;
    private NavMeshAgent _navMeshAgent;


    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        if (_targetFeedback != null)
            _targetFeedback.SetActive(false);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                
                SetDestination(hit.point);
                
                _targetFeedback.transform.position = new Vector3(hit.point.x,
                    hit.point.y + (transform.up * 0.02f).y,
                    hit.point.z);
                _targetFeedback.transform.forward = hit.normal;
            }
        }

        if (_targetFeedback != null)
            _targetFeedback.SetActive(!TargetReached());
    }

    private bool TargetReached()
    {
        if (!_navMeshAgent.pathPending)
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
                if (!_navMeshAgent.hasPath || _navMeshAgent.velocity.sqrMagnitude <= 0f)
                    return true;

        return false;
    }

    public void SetDestination(Vector3 position)
    {
        if (!_checkPath)
        {
            _navMeshAgent.SetDestination(position);
            return;
        }

        NavMeshPath path = new NavMeshPath();
        if (_navMeshAgent.CalculatePath(position, path))
            _navMeshAgent.SetDestination(position);
    }
}
