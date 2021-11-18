using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private GameEvent _firstExperimentFinished;
    [SerializeField] private GameEvent _secondExperimentFinished;
    [SerializeField] private GameEvent _practiceFinished;
    [SerializeField] private GameEvent _trialDone;
    [SerializeField] private Response _response;
    [SerializeField] private ExperimentStage _experimentStage;
    private void Awake()
    {
        _experimentStage.trialCount = 0;
        _experimentStage.stage = Stage.online;
        _experimentStage.practiceRound = true;
    }

    public void ResponseLogged()
    {
        _experimentStage.trialCount++;
        
        if (_experimentStage.practiceRound) //if we are in a practice round
        {
           if (_experimentStage.trialCount < _experimentStage.mootTrials) //if we haven't reached the last trial
           {
               _trialDone.Raise(); //go for another round
           }
           else //if we reached the last trial of this practice round
           {
               _experimentStage.trialCount = 0;
               _experimentStage.practiceRound = false;
               _practiceFinished.Raise(); //invoke task instruction UI once again
           }
        }
        else //if we are done with practice
        {
            if (_experimentStage.stage == Stage.online) //if we are doing online 
            {
                if (_experimentStage.trialCount < _experimentStage.numberOfTrials) //if we haven't reached the last trial
                {
                    _trialDone.Raise(); //go for another round
                }
                else //if we reached the last online trial, switch to offline
                {
                    _experimentStage.trialCount = 0;
                    _experimentStage.practiceRound = true;
                    _firstExperimentFinished.Raise();
                }    
            }
            else //if we are doing offline
            {
                if (_experimentStage.trialCount < _experimentStage.numberOfTrials) //if we haven't reached the last trial
                {
                    _trialDone.Raise(); //go for another round
                }
                else //if we reached the last trials
                {
                   _secondExperimentFinished.Raise();
                }
            }
        }
    }
}
