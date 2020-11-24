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

            var tween = transform.DOPath(pathPositions, _pathDuration, PathType.Linear, PathMode.Full3D,
                    resolution: 10, Color.yellow)
                .SetLookAt(0.01f);

            tween.onComplete += () => { transform.DOJump(transform.position, 3, 3, 2f);}
;        } 
    }
}
