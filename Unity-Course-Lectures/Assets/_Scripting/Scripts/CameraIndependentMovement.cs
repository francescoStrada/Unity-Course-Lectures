using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraIndependentMovement : MonoBehaviour
{
    public float Speed = 5;
    public bool CameraOrientationIndependent = false;
    public InputActionReference moveAction;

    private CameraSwitcher _cameraSwitcher;

    void OnEnable()
    {
        // Project-wide actions are shared by every script, so they are enabled here but never disabled
        moveAction.action.Enable();
    }

    void Start()
    {
        // Deprecated (as in the videos):
        // _cameraSwitcher = FindObjectOfType<CameraSwitcher>();
        _cameraSwitcher = FindAnyObjectByType<CameraSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        // Legacy Input (as in the videos):
        // float h = Input.GetAxis("Horizontal");
        // float v = Input.GetAxis("Vertical");
        Vector2 move = moveAction.action.ReadValue<Vector2>();
        float h = move.x;
        float v = move.y;
        Vector3 direction = new Vector3(h, 0f, v);
        
        if (CameraOrientationIndependent)
        {
            Camera activeCamera = _cameraSwitcher.ActiveCamera;
            direction = activeCamera.transform.TransformDirection(direction);
        }

        direction.y = 0;
        direction.Normalize();

        transform.Translate(direction * Speed * Time.deltaTime);
    }
}
