using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCallbacks : MonoBehaviour {

    public bool logUpdate;
    public bool logStrings;

    public string warningMessage;
    public string errorMessage;

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

        if (logStrings)
        {
            Debug.LogWarning(warningMessage);
            Debug.LogError(errorMessage);
        }
	}

    void FixedUpdate()
    {
        if (logUpdate)
            Debug.Log("FIXED UPDATE");
    }

    void Update ()
    {
        if (logUpdate)
            Debug.Log("UPDATE");
	}

    void LateUpdate()
    {
        if(logUpdate)
            Debug.Log("LATE UPDATE");
    }

    void OnDestroy()
    {
        Debug.Log("DESTROY");
    }
}
