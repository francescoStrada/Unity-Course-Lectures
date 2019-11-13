using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateController : MonoBehaviour
{
    public bool controFrameRate = false;
    public int targetFrameRate = 60;
    void Start()
    {
        if (controFrameRate)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = targetFrameRate;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
