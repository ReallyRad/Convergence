using System;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _noiseSource;
    [SerializeField] private AudioSource _stimulusSource;
    [SerializeField] private ExperimentStage _experimentStage;
    [SerializeField] private FloatVariable _currentVolume;
    [SerializeField] private Response _response;
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private GameEvent _audioFinishedEvent;

    [SerializeField] private float _probabilityCutoff;
    [SerializeField] private float _volumeIncrements;
    
    private bool _audioPlaying;
    
    private void Awake()
    {
        _currentVolume.Value = 0;
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

    public void Reset()
    {
        _currentVolume.Value = 0;
    }

    public void PlaySounds()
    {
        if (_experimentStage.trialCount > _experimentStage.mootTrials) 
        {
            var randomVal = UnityEngine.Random.Range(0f, 1f);
            
            if (randomVal <= _probabilityCutoff) //33% chance
            {
                _noiseSource.volume = 1f;
                _stimulusSource.volume = 1f;
            }
            else if (randomVal >= _probabilityCutoff) //66% chance
            {
                _noiseSource.volume = 1;
                _stimulusSource.volume = 0;
            }
        }

        _noiseSource.Play();
        _stimulusSource.Play();    
    }

    public void PlaySound(int sound)
    {
        if (sound == 1) _noiseSource.Play();
        if (sound == 2) _stimulusSource.Play();
    }
    
    public void OkButtonPressed()
    {
        if (_response.response == ResponseValue.yes &&  _experimentStage.trialCount >= _experimentStage.mootTrials)
        {
            _currentVolume.Value -= _volumeIncrements;
            _mixer.SetFloat("StimulusVolume", _currentVolume.Value);
        }
        PlaySounds();
    }
}
