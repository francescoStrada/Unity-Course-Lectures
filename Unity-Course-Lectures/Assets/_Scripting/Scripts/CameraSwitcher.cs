using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSwitcher : MonoBehaviour
{
    public List<Camera> SceneCameras;

    private Camera _activeCamera;
    private int _activeCameraIndex;

    public Camera ActiveCamera 
    {
        get { return _activeCamera; }
    }

    void Awake()
    {
        if (SceneCameras == null || SceneCameras.Count == 0)
        {
            Debug.LogWarning("No SceneCamera have been assigned to public field SceneCameras");
            return;
        }

        _activeCameraIndex = 0;
        ActivateCamera(_activeCameraIndex);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Increment activeCameraIndex, if the index is greater than the Cameras List size we return to index 0
            _activeCameraIndex++;
            if (_activeCameraIndex == SceneCameras.Count)
                _activeCameraIndex = 0;

            //Switch to Next Camera
            ActivateCamera(_activeCameraIndex);
        }
    }

    private void ActivateCamera(int cameraIndex)
    {
        if (cameraIndex > SceneCameras.Count)
        {
            Debug.LogError($"You are trying to activate a camera at index:{cameraIndex} but there are only {SceneCameras.Count} cameras");
            return;
        }

        for (int i = 0; i < SceneCameras.Count; i++)
        {
            if (i == cameraIndex)
            {
                SceneCameras[i].enabled = true;
                _activeCamera = SceneCameras[i];
            }

            if (i != cameraIndex)
                SceneCameras[i].enabled = false;
        }
    }
}
