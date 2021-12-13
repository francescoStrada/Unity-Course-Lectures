using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAudio : MonoBehaviour
{
    [SerializeField] private AudioClip _openingSound;
    [SerializeField] private AudioClip _closingSound;
    
    private Door _door;
    private AudioSource _doorAudioSource;
    void Start()
    {
        _door = GetComponentInChildren<Door>();
        if(_door != null)
        {
            _door.DoorRotating += PlayDoorAudio;
        }

        _doorAudioSource = GetComponentInChildren<AudioSource>();
    }

    private void PlayDoorAudio(bool isOpening)
    {
        if (_doorAudioSource != null)
        {
            AudioClip clipToPlay = isOpening ? _openingSound : _closingSound;
            _doorAudioSource.clip = clipToPlay;
            _doorAudioSource.Play();
        }
    }
}
