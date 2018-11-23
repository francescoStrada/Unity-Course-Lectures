using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Button3D : MonoBehaviour
{
    public Action OnButtonPressed;

    public Transform movingPieceT;
    public float localYFinalPressedPos;
    public float pressDuration = 0.3f;
    public float releaseDuration = 0.1f;

    public Color unpressedColor;
    public Color pressedColor;

    private MeshRenderer renderer;
    private bool isPressed = false;
    private float initialLocalYPos;

 
    void Start ()
    {
        initialLocalYPos = movingPieceT.localPosition.y;

        renderer = movingPieceT.GetComponent<MeshRenderer>();
        if (renderer != null)
            renderer.material.color = unpressedColor;

    }

    public void Press()
    {
        if (isPressed)
            return;

        isPressed = true;
        if (renderer != null)
            renderer.material.color = pressedColor;

        Sequence pressSequence = DOTween.Sequence();
        pressSequence.Append(movingPieceT.DOLocalMoveY(localYFinalPressedPos, pressDuration).OnComplete(() => 
        {
            //When Button has reached the end of travel rise event
            if (OnButtonPressed != null)
                OnButtonPressed();
        }));
        pressSequence.Append(movingPieceT.DOLocalMoveY(initialLocalYPos, releaseDuration));
        pressSequence.OnComplete(() => 
        {
            isPressed = false;
            if (renderer != null)
                renderer.material.color = unpressedColor;
        });
    }
}
