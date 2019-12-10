using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerGateway : MonoBehaviour
{
    [SerializeField] private string _forwardEntranceSceneToLoad;
    [SerializeField] private string _backwardEntranceSceneToLoad;

    [SerializeField] private LoadSceneMode _loadSceneMode;
    [SerializeField] private bool _unloadSceneOnExit;

    private AsyncOperation asyncLoadOperation;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        string sceneToLoad;
        bool forwardGateWayEntrance = IsEnteringForward(other.transform.position);

        if (forwardGateWayEntrance)
        {
            sceneToLoad = _forwardEntranceSceneToLoad;
        }
        else
        {
            sceneToLoad = _backwardEntranceSceneToLoad;
        }

        StartCoroutine(LoadNextScene(sceneToLoad));
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        
        if(!_unloadSceneOnExit)
            return;

        bool forwardGateWayEntrance = IsEnteringForward(other.transform.position);

        string sceneToUnloadName;
        if (forwardGateWayEntrance)
        {
            sceneToUnloadName = _forwardEntranceSceneToLoad;
        }
        else
        {
            sceneToUnloadName = _backwardEntranceSceneToLoad;
        }

        Scene sceneToUnload = SceneManager.GetSceneByName(sceneToUnloadName);
        if (!sceneToUnload.IsValid() || !sceneToUnload.isLoaded)
            return;

        StartCoroutine(UnloadScene(sceneToUnload));

    }

    private bool IsEnteringForward(Vector3 entrancePosition)
    {
        Vector3 entrancePositionRelativeToGateway = (entrancePosition - transform.position).normalized;
        
        //the result of the dot product returns < 0 player is entering the gateway in the same direction of the local forward 
        float dotResult = Vector3.Dot(entrancePositionRelativeToGateway, transform.forward);

        return dotResult <= 0f;
    }

    private IEnumerator LoadNextScene(string sceneToLoadName)
    {
        Scene sceneToLoad = SceneManager.GetSceneByName(sceneToLoadName);
        if (sceneToLoad.IsValid() && sceneToLoad.isLoaded)
            yield break;

        asyncLoadOperation = SceneManager.LoadSceneAsync(sceneToLoadName, _loadSceneMode);
        while (!asyncLoadOperation.isDone)
        {
            yield return null;
        }
        asyncLoadOperation = null;
        Scene loadedScene = SceneManager.GetSceneByName(sceneToLoadName);
        SceneManager.SetActiveScene(loadedScene);

    }

    private IEnumerator UnloadScene(Scene sceneToUnload)
    {
        while (asyncLoadOperation != null && !asyncLoadOperation.isDone)
        {
            yield return null;
        }

        SceneManager.UnloadSceneAsync(sceneToUnload);
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
