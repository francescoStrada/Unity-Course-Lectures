using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveAlongPath : MonoBehaviour
{
    [SerializeField] private Transform _waypointsRoot;
    [SerializeField] private float _pathDuration;
    
    // Start is called before the first frame update
    void Start()
    {
        if (_waypointsRoot != null && _waypointsRoot.childCount > 0)
        {
            Vector3[] pathPositions = new Vector3[_waypointsRoot.childCount];
            for (int i = 0; i < _waypointsRoot.childCount; i++)
                pathPositions[i] = _waypointsRoot.GetChild(i).position;

            transform.DOPath(pathPositions, _pathDuration, PathType.Linear, PathMode.Full3D, resolution: 20, Color.yellow)
                .SetLookAt(0.01f)
                .SetLoops(-1, LoopType.Yoyo);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
