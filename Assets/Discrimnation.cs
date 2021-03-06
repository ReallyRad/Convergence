using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ScriptableObjectArchitecture;
using UnityEngine;
using Debug = UnityEngine.Debug;

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
        if (there) _response.offlineResponse = ResponseValue.yes;
        else _response.offlineResponse = ResponseValue.no;
        _stopwatch.Stop();
        Debug.Log( "Time to answer discrimination rating :" + _stopwatch.ElapsedMilliseconds);
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
