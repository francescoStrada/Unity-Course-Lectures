using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    [SerializeField] private bool _persistent = false;

    void Awake()
    {
        if (_persistent)
            DontDestroyOnLoad(this);
    }
}
