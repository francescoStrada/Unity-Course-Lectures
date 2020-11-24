using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class TreasureChestOpener : MonoBehaviour
{
    private Animator _animator;

    private bool _open = false;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
            Open();
        if (Input.GetKeyDown(KeyCode.C))
            Close();
    }

    public void Open()
    {
        if (_animator == null)
            return;

        _open = true;

        _animator.SetBool("open", _open);
    }

    public void Close()
    {
        if (_animator == null)
            return;

        _open = false;

        _animator.SetBool("open", _open);
    }
}
