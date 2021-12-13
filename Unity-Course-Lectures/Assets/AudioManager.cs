using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _mainMixer;

    private AudioMixerSnapshot _soundtrackMixerSnapshot;
    private AudioMixerSnapshot _environmentMixerSnapshot;
    private AudioMixerSnapshot _narrativeMixerSnapshot;
    
    private void Start()
    {
        _soundtrackMixerSnapshot = _mainMixer.FindSnapshot("Soundtrack");
        _environmentMixerSnapshot = _mainMixer.FindSnapshot("Environment");
        _narrativeMixerSnapshot = _mainMixer.FindSnapshot("Voice");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _soundtrackMixerSnapshot.TransitionTo(2f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _environmentMixerSnapshot.TransitionTo(2f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _narrativeMixerSnapshot.TransitionTo(2f);
        }
    }
}
