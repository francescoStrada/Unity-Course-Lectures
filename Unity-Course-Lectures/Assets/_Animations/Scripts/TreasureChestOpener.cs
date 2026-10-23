using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null)
            return;

        // Legacy Input (as in the videos):
        // if(Input.GetKeyDown(KeyCode.O))
        if (keyboard.oKey.wasPressedThisFrame)
            Open();
        // if (Input.GetKeyDown(KeyCode.C))
        if (keyboard.cKey.wasPressedThisFrame)
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
