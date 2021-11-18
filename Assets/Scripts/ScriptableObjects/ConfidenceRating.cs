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
    [SerializeField] private ObjectGameEvent _OkButtonPressedEvent;
    [SerializeField] private Slider _confidenceSlider;
    [SerializeField] private Response _response;
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
        _stopwatch.Stop();
        Debug.Log( "Time to answer confidence rating :" + _stopwatch.ElapsedMilliseconds);
        _response.responseTime += (int) _stopwatch.ElapsedMilliseconds;
        _stopwatch.Reset();
        GetComponent<PanelDimmer>().Hide();
        _OkButtonPressedEvent.Raise();
        _response.responseTime = 0;
    }

    public void Show()
    {
        _stopwatch.Start();
        GetComponent<PanelDimmer>().Show();
        _confidenceSlider.value = 0.5f;    
    }
}
