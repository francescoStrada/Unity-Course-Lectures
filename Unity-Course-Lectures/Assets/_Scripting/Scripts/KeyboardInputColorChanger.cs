using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInputColorChanger : MonoBehaviour
{
    private Color[] _colors = new[]
        {Color.red, Color.blue, Color.green, Color.magenta, Color.white, Color.cyan, Color.yellow, Color.black};

    private Renderer _renderer;
    
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        if (_renderer == null)
        {
            Debug.LogWarning($"There is no Renderer attached to GameObject named:{gameObject.name}");
        }
    }

    
    void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null)
            return;

        // Legacy Input (as in the videos):
        // if(Input.GetKeyDown(KeyCode.Space))
        if (keyboard.spaceKey.wasPressedThisFrame)
            ChangeColor();

        // if (Input.GetKey(KeyCode.Space))
        //if (keyboard.spaceKey.isPressed)
          //  ChangeColor();

        // if (Input.GetKeyUp(KeyCode.Space))
        if (keyboard.spaceKey.wasReleasedThisFrame)
            ChangeColor();
    }

    private void ChangeColor()
    {
        if(_renderer == null)
            return;
        _renderer.material.color = _colors[Random.Range(0, _colors.Length)];
    }
}
