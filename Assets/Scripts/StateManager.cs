using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private GameEvent _experimentFinished;
    [SerializeField] private GameEvent _practiceFinihsed;
    [SerializeField] private Response _response;
    [SerializeField] private ExperimentStage _experimentStage;
    private void Awake()
    {
        _experimentStage.trialCount = 0;
        _experimentStage.stage = Stage.online;
        _experimentStage.practiceRound = true;
    }

    public void TrialDone()
    {
        _experimentStage.trialCount++;
        if (_experimentStage.practiceRound) //if we are in a practice round
        {
               //if we reached last trial
               if (_experimentStage.trialCount < _experimentStage.mootTrials) //if we haven't reached the last trial
               {
                   
               }
               else //if we reached the last trial of this practice round
               {
                   _experimentStage.trialCount = 0;
                   _experimentStage.practiceRound = false;
                   _practiceFinihsed.Raise();
               }
        }
        else //if we are done with practice
        {
            if (_experimentStage.stage == Stage.offline) //if we are doing offline 
            {
                if (_experimentStage.trialCount < _experimentStage.numberOfTrials) //if we haven't reached the last trial
                {
                    _response.response = ResponseValue.none;
                    _response.confidence = 0.5f;    
                }
                else //if we reached the last trials
                {
                    _experimentStage.stage = Stage.offline;
                    _experimentFinished.Raise();
                }    
            }
            else //if we are doing online
            {
                if (_experimentStage.trialCount < _experimentStage.numberOfTrials) //if we haven't reached the last trial
                {
                    
                }
            }

        }
        
    }
    
}
