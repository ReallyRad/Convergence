using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private IntVariable _trialCount;


    private void Awake()
    {
        _trialCount.Value = 0;
    }
}
