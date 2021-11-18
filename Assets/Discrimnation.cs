using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ScriptableObjectArchitecture;
using UnityEngine;

public class Discrimnation : MonoBehaviour
{
    private Stopwatch _stopwatch;
    [SerializeField] private GameEvent _discriminationDone;
    [SerializeField] private Response _response;

    private void Awake()
    {
        _stopwatch = new Stopwatch();
    }
    
    public void MelodyThere(bool there)
    {
        if (there) _response.response = ResponseValue.yes;
        else _response.response = ResponseValue.no;
        _stopwatch.Stop();
        _response.responseTime += (int) _stopwatch.ElapsedMilliseconds;
        _discriminationDone.Raise();
        _stopwatch.Reset();
    }

    public void Show()
    {
        GetComponent<PanelDimmer>().Show();
        _stopwatch.Start();
    }
}
