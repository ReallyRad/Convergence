using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private IntVariable _trialCount;
    [SerializeField] private IntVariable _numberOfTrials;
    [SerializeField] private GameEvent _experimentFinished;
    [SerializeField] private Response _response;
    [SerializeField] private ExperimentStage _experimentStage;

    private void Awake()
    {
        _trialCount.Value = 0;
        _experimentStage.stage = Stage.online;
    }

    public void TrialDone()
    {
        _trialCount.Value++;
        if (_trialCount.Value < _numberOfTrials.Value)
        {
            _response.response = ResponseValue.none;
            _response.confidence = 0.5f;    
        } else
            _experimentFinished.Raise();
    }
    
}
