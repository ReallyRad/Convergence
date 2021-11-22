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

    public void OkButtonPressed(Response response)
    {
        if (!_experimentStage.practiceRound)
        {
            response.SetResponseValueTypes(_stimulusSource.volume);

            if (response.offlineResponseType == ResponseType.truePositive)
                _stimulusSource.volume -= _volumeIncrements;
            else if (response.offlineResponseType == ResponseType.falseNegative)
                _stimulusSource.volume += _volumeIncrements;


            _mixer.SetFloat("StimulusVolume", _currentVolume.Value);
        
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

        _response.offlineResponse = ResponseValue.none;
        _response.onlineResponse = ResponseValue.none;
        _response.confidence = 0.5f;    

        _noiseSource.Play();
        _stimulusSource.Play();    
    }

}
