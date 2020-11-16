using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : Interactable
{
    [SerializeField] private Door _door;

    private Collider _interactableCollider;

    void Start()
    {
        _door.DoorClosed += OnDoorClosed;
        _interactableCollider = GetComponent<Collider>();
    }
    
    public override void Interact(GameObject caller)
    {
        _interactableCollider.enabled = false;

        Vector3 othersPositionRelativeToDoor = (caller.transform.position - transform.position).normalized;

        //the result of the dot product returns > 0 if relative position 
        float dotResult = Vector3.Dot(othersPositionRelativeToDoor, transform.forward);

        float doorRotation = dotResult > 0 ? 90f : -90f;

        if (_door != null)
            _door.OpenDoor(doorRotation);
    }

    private void OnDoorClosed()
    {
        _interactableCollider.enabled = true;
    }


}
