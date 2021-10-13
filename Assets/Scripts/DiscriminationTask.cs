using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.UI;

public class DiscriminationTask : MonoBehaviour
{
    [SerializeField] private Response _response;
    [SerializeField] private ObjectGameEvent _OkButtonPressedEvent;
    [SerializeField] private Slider _confidenceSlider;

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
        _confidenceSlider.value = 0.5f;
    }
    
}
