using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject _doorHindge;
    [SerializeField] private float _openingTime = 1f;
    [SerializeField] private float _closingTime = 0.5f;

    private bool _isRotating = false;
    private bool _isOpen = false;
    private Quaternion _originalRotation;

    private void Start()
    {
        _originalRotation = _doorHindge.transform.localRotation;
    }

    public void OpenDoor(float rotation)
    {
        if (_isRotating || _isOpen)
            return;

        Quaternion targetRotation = Quaternion.Euler(_originalRotation.x, rotation, _originalRotation.z);
        StartCoroutine(AnimateDoor(targetRotation, _openingTime));
    }

    public void CloseDoor()
    {
        if (_isRotating || !_isOpen)
            return;

        StartCoroutine(AnimateDoor(_originalRotation, _closingTime));
    }

    private IEnumerator AnimateDoor(Quaternion targetRotation, float animationTime)
    {
        _isRotating = true;

        float animationTimer = 0;
        Quaternion startRotation = _doorHindge.transform.localRotation;
         
        while (animationTimer < animationTime)
        {
            animationTimer += Time.deltaTime;
            _doorHindge.transform.localRotation = Quaternion.Lerp(startRotation, targetRotation, animationTimer / animationTime);
            yield return null;
        }

        _isRotating = false;
        _isOpen = !_isOpen;
    }

    public void OpenAndClose(float rotation)
    {
        OpenDoor(rotation);
        Invoke("CloseDoor", _openingTime + 0.5f);
    }




}
