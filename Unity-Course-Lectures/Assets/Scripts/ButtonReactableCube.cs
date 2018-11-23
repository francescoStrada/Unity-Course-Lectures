using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ButtonReactableCube : MonoBehaviour
{
    public Button3D changeColorButton, changeScaleButton, changeYPosButton;

    public List<Color> colors;
    public float maxScaleVariation = 2f;
    public float maxYPosVariation = 3f;

    private MeshRenderer renderer;
    private Vector3 initialPos;
    private Vector3 initialScale;

    // Use this for initialization
    void Start ()
    {
        changeColorButton.OnButtonPressed += OnChangeColorButtonPressed;
        changeScaleButton.OnButtonPressed += OnChangeScaleButtonPressed;
        changeYPosButton.OnButtonPressed += OnChangeYPosButtonPressed;

        renderer = GetComponent<MeshRenderer>();

        initialPos = transform.position;
        initialScale = transform.localScale;

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            transform.position = initialPos;
            transform.localScale = initialScale;
        }
    }

    private void OnChangeColorButtonPressed()
    {
        if (colors.Count == 0)
            return;

        int randomIndex = Random.Range(0, colors.Count - 1);
        Color randomColor = colors[randomIndex];
        if (renderer != null)
            renderer.material.color = randomColor;
    }

    private void OnChangeScaleButtonPressed()
    {
        float xRandomVariation = Random.Range(0.5f, maxScaleVariation);
        float yRandomVariation = Random.Range(0.5f, maxScaleVariation);
        float zRandomVariation = Random.Range(0.5f, maxScaleVariation);

        Vector3 newScaleVector = new Vector3(transform.localScale.x * xRandomVariation,
                                              transform.localScale.y * yRandomVariation,
                                              transform.localScale.z * zRandomVariation);

        transform.localScale = newScaleVector;

    }

    private void OnChangeYPosButtonPressed()
    {
        float randomYPosVariation = Random.Range(-maxYPosVariation, maxYPosVariation);
        transform.position = new Vector3(transform.position.x, 
                                            transform.position.y * randomYPosVariation, 
                                            transform.position.z);
    }

}
