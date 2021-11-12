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
        } 
        else if (_stimulusSource.isPlaying)
        {
            _audioPlaying = true;
        }
    }

    public void Reset()
    {
        _currentVolume.Value = 0;
        _response.responseTime = 0;
    }

    public void PlaySounds()
    {
        if (_experimentStage.trialCount > _experimentStage.mootTrials) 
        {
            var randomVal = UnityEngine.Random.Range(0f, 1f); //pick a random number between 0 and 1
            
            if (randomVal <= _probabilityCutoff) //1 in probablalityCutoff times, play both sounds 
            {
                _noiseSource.volume = 1f; 
                _stimulusSource.volume = 1f;
            }
            else if (randomVal >= _probabilityCutoff) //1 in 1 - probabilityCutoff times, play noise only 
            {
                _noiseSource.volume = 1f;
                _stimulusSource.volume = 0f;
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
    
    public void OkButtonPressed(Response response)
    {
        Debug.Log("AudioManager");
        if (!_experimentStage.practiceRound)
        {
            if (response.response == ResponseValue.yes && _stimulusSource.volume == 1f) //true positive 
            {
                _currentVolume.Value -= _volumeIncrements; //decrement
                _response.responseType = ResponseType.truePositive;
            } else if (response.response == ResponseValue.no || _response.response == ResponseValue.none && _stimulusSource.volume == 1f) //false negative
            {
                _currentVolume.Value += _volumeIncrements; //decrement
                _response.responseType = ResponseType.falseNegative;
            } else if (response.response == ResponseValue.yes && _stimulusSource.volume != 1f) //false positive
            {
                _response.responseType = ResponseType.falsePositive;
            } else if (response.response == ResponseValue.no || _response.response == ResponseValue.none && _stimulusSource.volume != 1f) //true negative
            {
                _currentVolume.Value += _volumeIncrements;
                response.responseType = ResponseType.trueNegative;
            }
        }
        
        _mixer.SetFloat("StimulusVolume", _currentVolume.Value);
        PlaySounds();
    }

}
