using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectRotation : MonoBehaviour
{
    
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.RotateAround(transform.parent.position, Vector3.up, 20 * Time.deltaTime);
    }
}
