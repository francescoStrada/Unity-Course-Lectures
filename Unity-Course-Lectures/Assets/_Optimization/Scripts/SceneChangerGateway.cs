using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class SceneChangerGateway : MonoBehaviour
{
    [SerializeField] private string _forwardEntranceSceneToLoad;
    [SerializeField] private string _backwardEntranceSceneToLoad;

    [SerializeField] private bool _unloadSceneOnExit;

    private string _sceneToLoad, _sceneToUnload;

    private string _lastLoadedScene, _newlyLoadedScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        bool forwardGateWayEntrance = IsEnteringForward(other.transform.position);

        if (forwardGateWayEntrance)
        {
            _sceneToLoad = _forwardEntranceSceneToLoad;
            _sceneToUnload = _backwardEntranceSceneToLoad;
        }
        else
        {
            _sceneToLoad = _backwardEntranceSceneToLoad;
            _sceneToUnload = _forwardEntranceSceneToLoad;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        
        if(!_unloadSceneOnExit)
            return;
    }

    private bool IsEnteringForward(Vector3 entrancePosition)
    {
        Vector3 entrancePositionRelativeToGateway = (entrancePosition - transform.position).normalized;
        
        //the result of the dot product returns < 0 player is entering the gateway in the same direction of the local forward 
        float dotResult = Vector3.Dot(entrancePositionRelativeToGateway, transform.forward);

        return dotResult <= 0f;

    }

    private void OnDrawGizmos()
    {
        Vector3 forwardGatewayEnterPosition = transform.position + -transform.forward * (transform.localScale.z / 2f);
        Vector3 backwardGatewayEnterPosition = transform.position + transform.forward * (transform.localScale.z / 2f);

        
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(forwardGatewayEnterPosition, 1f);
        Gizmos.color = Color.red; 
        Gizmos.DrawSphere(backwardGatewayEnterPosition, 1f);
    }
}
