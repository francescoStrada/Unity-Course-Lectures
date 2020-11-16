using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionColorChanger : MonoBehaviour
{
    [SerializeField] private Color _collisionColor;

    private Color _originalColor;
    private Renderer _renderer;

    void Start()
    {
        _renderer = GetComponent<Renderer>();
        if (_renderer != null)
            _originalColor = _renderer.material.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_renderer == null)
            return;

        _renderer.material.color = _collisionColor;
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (_renderer == null)
            return;

        _renderer.material.color = _originalColor;
    }
}
