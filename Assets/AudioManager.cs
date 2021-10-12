using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _noiseSource;
    [SerializeField] private AudioSource _stimulusSource;
    [SerializeField] private IntVariable _trialCount;
    [SerializeField] private IntVariable _mootTrials;
    [SerializeField] private FloatVariable _curentVolume;

    public void PlaySounds()
    {
        _trialCount.Value++;
        if (_trialCount.Value < _mootTrials.Value)
        {
            _noiseSource.Play();
            _stimulusSource.Play();    
        }
    }
}
