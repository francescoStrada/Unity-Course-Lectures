using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
        if(Input.GetKeyDown(KeyCode.Space))
            ChangeColor();

        //if (Input.GetKey(KeyCode.Space))
          //  ChangeColor();

        if (Input.GetKeyUp(KeyCode.Space))
            ChangeColor();
    }

    private void ChangeColor()
    {
        if(_renderer == null)
            return;
        _renderer.material.color = _colors[Random.Range(0, _colors.Length)];
    }
}
