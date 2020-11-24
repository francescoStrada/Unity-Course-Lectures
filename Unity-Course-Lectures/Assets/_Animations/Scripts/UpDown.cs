using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    [SerializeField] private float _height;
    void Start()
    {
        float startY = transform.position.y;
        Sequence moveSequence = DOTween.Sequence();
        moveSequence.Append(transform.DOMoveY(_height, 1));
        moveSequence.Append(transform.DOMoveY(startY, 1));
        moveSequence.Append(transform.DOShakeScale(1f, new Vector3(0.5f, 0.5f, 0.5f)));
        moveSequence.OnComplete(() =>
        {
            transform.GetComponent<Renderer>().material.color = Color.green;
            
        });

        moveSequence.Play();
    }

   
}
