using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcclusionPortalActivator : MonoBehaviour
{
    private OcclusionPortal _portal;
    private Door _door;
    void Start()
    {
        _portal = GetComponent<OcclusionPortal>();
        _door = GetComponent<Door>();
        if(_door != null)
        {
            _door.DoorClosed += () => _portal.open = false;
            _door.DoorRotating += OnDoorRotating;
        }
    }

    private void OnDoorRotating(bool isOpening)
    {
        if (isOpening && _portal != null)
            _portal.open = true;
            
    }
}
