using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraIndependentMovement : MonoBehaviour
{
    public float Speed = 5;
    public bool CameraOrientationIndependent = false;

    private CameraSwitcher _cameraSwitcher;

    void Start()
    {
        _cameraSwitcher = FindObjectOfType<CameraSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
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
