﻿using System;
using ScriptableObjectArchitecture;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private GameEvent _experimentFinished;
    [SerializeField] private GameEvent _practiceFinished;
    [SerializeField] private GameEvent _showPracticeInstructions;
    [SerializeField] private GameEvent _trialDone;
    [SerializeField] private GameEvent _showEndPanel;
    [SerializeField] private ExperimentStage _experimentStage;
    [SerializeField] private bool _separateOnlineAndOffline;

    private void Awake()
    {
        _experimentStage.trialCount = 0;
        _experimentStage.practiceRound = true;
        _experimentStage.alwaysShowingStimulus = true;
    }

    private void Start()
    {
        _experimentStage.stage = Stage.online;
    }

    public void ResponseLogged()
    {
        _experimentStage.trialCount++;
        
        if (_experimentStage.practiceRound) //if we are in a practice round
        {
           if (_experimentStage.trialCount < _experimentStage.practiceTrials) //if we haven't reached the last trial
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
            if (_separateOnlineAndOffline)
            {
                //TODO allow to randomise order between
                if (_experimentStage.stage == Stage.online) //if we are doing online 
                {
                    if (_experimentStage.trialCount < _experimentStage.numberOfTrials) //if we haven't reached the last trial
                    {
                        _trialDone.Raise(); //go for another round
                    }
                    else //if we reached the last online trial, switch to offline
                    {
                        _experimentStage.practiceRound = true;
                        _experimentStage.trialCount = 0;
                        _experimentFinished.Raise();
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
                        _experimentStage.trialCount = 0;
                        _experimentFinished.Raise();
                    }
                }
            }
            else
            {
                //TODO implement merged online/offline version too
                if (_experimentStage.trialCount < _experimentStage.numberOfTrials) //if we haven't reached the last trial
                {
                    _experimentStage.trialCount = 0;
                    _trialDone.Raise(); //go for another round
                }
                else //if we reached the last online trial, switch to offline
                {
                    _experimentFinished.Raise();
                }
            }
        }
    }

    public void FeedbackOkButtonPressed()
    {
        //TODO implement randomising online/offline here
        if (_experimentStage.stage == Stage.online)
        {
            _experimentStage.stage = Stage.offline; //switch to offline
            _showPracticeInstructions.Raise();
        }
        else
        {
            _showEndPanel.Raise();
        }
    }
}
 