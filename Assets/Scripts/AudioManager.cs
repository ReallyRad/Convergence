using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _noiseSource;
    [SerializeField] private AudioSource _stimulusSource;
    [SerializeField] private IntVariable _trialCount;
    [SerializeField] private IntVariable _mootTrials;
    [SerializeField] private FloatVariable _curentVolume;
    [SerializeField] private Response _response;

    [SerializeField] private AudioMixer _mixer;
    
    public void PlaySounds()
    {
        if (_trialCount.Value > _mootTrials.Value) 
        {
            var randomVal = UnityEngine.Random.Range(0f, 1f);
            
            if (randomVal <= 0.333) //33% chance
            {
                _noiseSource.volume = _curentVolume.Value;
                _stimulusSource.volume = _curentVolume.Value;
            }
            else if (randomVal >= 0.333) //66% chance
            {
                _noiseSource.volume = _curentVolume.Value;
                _stimulusSource.volume = 0;
            }
        }

        _noiseSource.Play();
        _stimulusSource.Play();    
    }

    public void OkButtonPressed()
    {
        if (_response.response == ResponseValue.yes && _trialCount >= 5)
        {
            _curentVolume.Value -= 1;
            _mixer.SetFloat("StimulusVolume", _curentVolume.Value);
        }
    }

}
