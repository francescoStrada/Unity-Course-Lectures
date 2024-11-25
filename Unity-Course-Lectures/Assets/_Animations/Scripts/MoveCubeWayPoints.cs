using UnityEngine;
using System.Collections;

public class MoveCubeWayPoints : MonoBehaviour
{
    [SerializeField] private Transform wayPointsT;
    [SerializeField] private bool _useCoroutine;
    
    [Range(0.001f, 0.5f)][SerializeField] private float _nextWayPointWaitTime;

    private Coroutine _coroutine = null;

    private int _currentWaypointIndex = 0;
    // Use this for initialization
    void Start()
    {
        if (_useCoroutine)
            _coroutine = StartCoroutine(MoveAlongWaypointsCoroutine());
    }

    

    // Update is called once per frame
    void Update()
    {
        if (_useCoroutine)
        {
            if (Input.GetKeyDown(KeyCode.S) && _coroutine == null)
                _coroutine = StartCoroutine(MoveAlongWaypointsCoroutine());
            
            else if (Input.GetKeyDown(KeyCode.S) && _coroutine != null)
            {
                StopCoroutine(_coroutine);
                _coroutine = null;
            }

            return;
        }

        for (int i = 0; i < wayPointsT.childCount; i++)
        {
            Vector3 wayPointPosition = wayPointsT.GetChild(i).position;
            transform.position = new Vector3(wayPointPosition.x, transform.position.y, wayPointPosition.z);
        }

    }

    private IEnumerator MoveAlongWaypointsCoroutine()
    {
        while (true)
        {
            for (int i = _currentWaypointIndex; i < wayPointsT.childCount; i++)
            {
                Vector3 wayPointPosition = wayPointsT.GetChild(i).position;
                transform.position = new Vector3(wayPointPosition.x, transform.position.y, wayPointPosition.z);
                _currentWaypointIndex = i;
                yield return new WaitForSeconds(_nextWayPointWaitTime);
            }
        }
    }
}
