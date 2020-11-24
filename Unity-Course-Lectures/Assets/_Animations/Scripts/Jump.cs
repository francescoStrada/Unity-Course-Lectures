using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Jump : MonoBehaviour
{
    [SerializeField] private float _jumpDistance;

    void Start()
    {
        transform.DOJump(transform.position + transform.forward * _jumpDistance, 3f, 1, 0.8f).SetLoops(-1, LoopType.Yoyo);
    }
}
