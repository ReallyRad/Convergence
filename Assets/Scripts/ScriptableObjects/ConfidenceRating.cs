using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class ConfidenceRating : MonoBehaviour
{
    [SerializeField] private Response _response;
    [SerializeField] private ObjectGameEvent _OkButtonPressedEvent;
    [SerializeField] private Slider _confidenceSlider;
    [SerializeField] private ExperimentStage _experimentStage;
    private Stopwatch _stopwatch;

    private void OnEnable()
    {
        _confidenceSlider.onValueChanged.AddListener(delegate(float value)
        {
            _response.confidence = value;
        });
    }

    private void Awake()
    {
        _stopwatch = new Stopwatch();
    }

    public void OKButtonPressed()
    {
        //if (_stage == Stage.offline)
        //{
            _stopwatch.Stop();
            Debug.Log( "Time to answer :" + _stopwatch.ElapsedMilliseconds);
            _stopwatch.Reset();
        //}
        GetComponent<PanelDimmer>().Hide();
        _OkButtonPressedEvent.Raise();
        _response.responseTime = 0;
    }

    public void MelodyThere(bool there)
    {
        if(there) _response.response = ResponseValue.yes;
        else _response.response = ResponseValue.no;
    }

    public void Reset()
    {
        _stopwatch.Start();
        GetComponent<PanelDimmer>().Show();
        _confidenceSlider.value = 0.5f;    
    }
}
