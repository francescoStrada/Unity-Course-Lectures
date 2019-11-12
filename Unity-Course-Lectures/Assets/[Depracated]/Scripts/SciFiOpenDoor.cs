using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SciFiOpenDoor : MonoBehaviour {

    [SerializeField] private Animator _doorAnimator;

    public void OnTriggerEnter(Collider other)
    {
        if (_doorAnimator == null)
            return;

        if(other.CompareTag("Player"))
            _doorAnimator.SetBool("character_nearby", true);
    }

    public void OnTriggerExit(Collider other)
    {
        if (_doorAnimator == null)
            return;

        if (other.CompareTag("Player"))
            _doorAnimator.SetBool("character_nearby", false);
    }


}
