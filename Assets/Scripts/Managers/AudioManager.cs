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
    [SerializeField] private float _practiceVolumeIncrements;

    [SerializeField] private float _initialVolume;
    
    private bool _audioPlaying;
    [SerializeField] private int _playSoundEvery; //include a variable determine to show the melody at -5DB every X trial. 

    private void Awake()
    {
        _currentVolume.Value = _initialVolume;
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

    public void OkButtonPressed(Response response)
    {
        if (!_experimentStage.practiceRound)
        {
            response.SetResponseValueTypes(_stimulusSource.volume);   
            
            if (response.responseType == ResponseType.truePositive) _currentVolume.Value -= _volumeIncrements;
            else if (response.responseType == ResponseType.falseNegative) _currentVolume.Value += _volumeIncrements;
        
            if (_experimentStage.trialCount > _experimentStage.alwaysStimulusTrials) //if we had enough trials with stimulus always on
            {
                if (response.confidence < _experimentStage.perceptualAmbiguityThreshold) //if the subject is not sure whether he heard the stimulus anymore
                {
                    _experimentStage.alwaysShowingStimulus = false;
                }

                if (!_experimentStage.alwaysShowingStimulus)
                {
                    var randomVal = UnityEngine.Random.Range(0f, 1f); //pick a random number between 0 and 1
            
                    if (randomVal <= _probabilityCutoff) //1 in probabilityCutoff times, play both sounds 
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
            }
        }
        else //if in practice
        {
            _currentVolume.Value -= _practiceVolumeIncrements;
        }

        if (_experimentStage.practiceRound || _experimentStage.trialCount % _playSoundEvery != 0)
        {
            _mixer.SetFloat("StimulusVolume", _currentVolume.Value);
            response.currentVolume = _currentVolume.Value;
        }
        else if (_experimentStage.trialCount % _playSoundEvery == 0)
        {
            _mixer.SetFloat("StimulusVolume", 0);
            _stimulusSource.volume = 1f;
            response.currentVolume = 0;
        }  
            
        _response.response = ResponseValue.none;
        _response.confidence = 0.5f;
        
        _noiseSource.Play();
        _stimulusSource.Play();    
    }

}
