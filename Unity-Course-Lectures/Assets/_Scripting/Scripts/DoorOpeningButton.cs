using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningButton : MonoBehaviour
{
    [SerializeField] private Button3D _openDoorButton;
    [SerializeField] private Door _door;
    void Start()
    {
        _openDoorButton.OnButtonPressed += OnDoorOpenButtonPressed;
    }

    private void OnDoorOpenButtonPressed()
    {
        int randomrotation = Random.Range(-90, 90);
        int numSteps = (int)Mathf.Floor(randomrotation / 15f);
        int adjustedRotation = numSteps * 15;

        _door.OpenAndClose(adjustedRotation);
    }
}
