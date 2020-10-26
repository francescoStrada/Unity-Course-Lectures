using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCallbacks : MonoBehaviour {

    public bool LogAwakeMessages;

    public string WarningMessage;
    public string ErrorMessage;

    void Awake()
    {
        Debug.Log("AWAKE");
    }

    void OnEnable()
    {
        Debug.Log("ENABLE");
    }

    void Start ()
    {
        Debug.Log("START");

        if (LogAwakeMessages)
        {
            Debug.LogWarning(WarningMessage);
            Debug.LogError(ErrorMessage);
        }
	}

    void FixedUpdate()
    { 
        Debug.Log("FIXED UPDATE");
    }

    void Update ()
    {
        Debug.Log("UPDATE");
	}

    void LateUpdate()
    {
        Debug.Log("LATE UPDATE");
    }

    void OnDisable()
    {
        Debug.Log("ON DISABLE");
    }

    void OnDestroy()
    {
        Debug.Log("DESTROY");
    }
}
