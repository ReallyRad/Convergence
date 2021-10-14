using System;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _noiseSource;
    [SerializeField] private AudioSource _stimulusSource;
    [SerializeField] private IntVariable _trialCount;
    [SerializeField] private IntVariable _mootTrials;
    [SerializeField] private FloatVariable _currentVolume;
    [SerializeField] private Response _response;
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private GameEvent _audioFinishedEvent;

    private bool _audioPlaying;
    
    private void Awake()
    {
        _currentVolume.Value = 0;
    }

    private void Start()
    {
        PlaySounds();
    }

    private void Update()
    {
        if (!_stimulusSource.isPlaying)
        {
            if (_audioPlaying) //audio source just finished playing
            {
                _audioFinishedEvent.Raise();
            }
            _audioPlaying = false;
        } else if (_stimulusSource.isPlaying)
        {
            _audioPlaying = true;
        }
    }

    public void PlaySounds()
    {
        if (_trialCount.Value > _mootTrials.Value) 
        {
            var randomVal = UnityEngine.Random.Range(0f, 1f);
            
            if (randomVal <= 0.333) //33% chance
            {
                _noiseSource.volume = 1f;
                _stimulusSource.volume = 1f;
            }
            else if (randomVal >= 0.333) //66% chance
            {
                _noiseSource.volume = 1;
                _stimulusSource.volume = 0;
            }
        }

        _noiseSource.Play();
        _stimulusSource.Play();    
    }

    public void OkButtonPressed()
    {
        if (_response.response == ResponseValue.yes && _trialCount >= _mootTrials.Value)
        {
            _currentVolume.Value -= 1;
            _mixer.SetFloat("StimulusVolume", _currentVolume.Value);
        }
        PlaySounds();
    }
}
