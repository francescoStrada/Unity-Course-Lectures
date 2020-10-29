using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardsActiveCamera : MonoBehaviour
{
    private Camera[] _cameras;
    void Start()
    {
        _cameras = FindObjectsOfType<Camera>();
    }

    
    void Update()
    {
        for (int i = 0; i < _cameras.Length; i++)
        {
            if (!_cameras[i].enabled)
                continue;

            Vector3 cameraToFaceForward = _cameras[i].transform.forward;
            cameraToFaceForward.y = 0f;
            transform.forward = cameraToFaceForward;
        }
    }
}
