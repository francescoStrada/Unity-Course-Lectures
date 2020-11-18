using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRaycaster : MonoBehaviour
{
    [SerializeField] private Transform _fpsCameraT;
    [SerializeField] private float _raycastDistance;
    [SerializeField] private bool _debugHitDistance = false;

    private CharacterController _fpsController;

    void Start()
    {
        _fpsController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 rayOrigin = _fpsCameraT.position + _fpsCameraT.forward * _fpsController.radius;
        Ray ray = new Ray(rayOrigin, _fpsCameraT.forward);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _raycastDistance))
        {
            //Get information on the hitted object
            Debug.Log($"Raycast Hit GameObject:{hit.transform.name}");
            
            if(_debugHitDistance)
                Debug.Log($"Raycast Hit GameObject:{hit.transform.name} at a distance of:{hit.distance}");

            //Show the normal of the surface hitted by the raycast
            Debug.DrawRay(hit.point, hit.normal * 1f, Color.green);
        }
       
        Debug.DrawRay(rayOrigin, _fpsCameraT.forward * _raycastDistance, Color.red);

    }
}
