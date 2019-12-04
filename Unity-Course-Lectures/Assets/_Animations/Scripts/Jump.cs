using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Jump : MonoBehaviour
{
    [SerializeField] private float _jumpDistance;

    // Start is called before the first frame update
    void Start()
    {
        transform.DOJump(transform.position + transform.forward * _jumpDistance, 3f, 1, 0.8f).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
