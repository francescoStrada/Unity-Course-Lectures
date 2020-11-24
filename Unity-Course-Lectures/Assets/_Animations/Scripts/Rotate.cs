using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.DORotate(new Vector3(0f,90f,0f), 1f, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Incremental);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
