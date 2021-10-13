﻿using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private IntVariable _trialCount;
    [SerializeField] private Response _response;
    [SerializeField] private FloatVariable _currentVolume;

    private void Awake()
    {
        _trialCount.Value = 0;
    }

    public void TrialDone()
    {
        _trialCount.Value++;
        _response.response = ResponseValue.none;
        _response.confidence = 0.5f;
    }
    
}
