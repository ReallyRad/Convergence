using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;

public class ConfidenceRating : MonoBehaviour
{
    [SerializeField] private Response _response;
    [SerializeField] private ObjectGameEvent _OkButtonPressedEvent;
    [SerializeField] private Slider _confidenceSlider;
    [SerializeField] private Stage _stage;
    [SerializeField] private ExperimentStage _experimentStage;
    private void OnEnable()
    {
        _confidenceSlider.onValueChanged.AddListener(delegate(float value)
        {
            _response.confidence = value;
        });
    }

    public void OKButtonPressed()
    {
        GetComponent<PanelDimmer>().Hide();
        _OkButtonPressedEvent.Raise();
    }

    public void MelodyThere(bool there)
    {
        if(there) _response.response = ResponseValue.yes;
        else _response.response = ResponseValue.no;
    }

    public void Reset()
    {
        if (_experimentStage.stage == _stage)
        {
            GetComponent<PanelDimmer>().Show();
            _confidenceSlider.value = 0.5f;    
        }
    }
}
