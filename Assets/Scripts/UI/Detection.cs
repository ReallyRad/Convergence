using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class Detection : MonoBehaviour
{
    public Stage stage;
    
    [SerializeField] private ExperimentStage _experimentStage;
    [SerializeField] private Response _response;
    [SerializeField] private TMP_Text _text;
    private Stopwatch _stopwatch;
    private bool _bPressed;
    
    private void Awake()
    {
        _stopwatch = new Stopwatch();
    }

    public void ReadyToShow()
    {
        if (stage == _experimentStage.stage)
        {
            GetComponent<PanelDimmer>().Show();
            if (stage == Stage.offline)
                _text.text ="Listen...";
            else if (stage == Stage.online)
                _text.text ="Listen...\n\n\n\n  Press \"B\" when you hear the melody";

            _response.response = ResponseValue.none;
            if (_experimentStage.stage == Stage.online)
            {
                _stopwatch.Start();
                Debug.Log("starting stopwatch");
                _bPressed = false;
            }
        }
    }

    public void AudioFinished()
    {
        if (_experimentStage.stage == stage)
        {
            GetComponent<PanelDimmer>().Hide();
            if (_response.response == ResponseValue.none && _experimentStage.stage == Stage.online)
            {
                _response.response = ResponseValue.no;
                _stopwatch.Stop();
                _stopwatch.Reset();
            }
        }
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.B) && _experimentStage.stage == Stage.online && stage == Stage.online && !_bPressed)
        {
            _stopwatch.Stop();
            Debug.Log("B pressed. response time = " + _stopwatch.ElapsedMilliseconds);
            _text.text ="Listen...\n\n\n\n  \"B\" press detected";
            _response.response = ResponseValue.yes;
            _response.responseTime = _stopwatch.ElapsedMilliseconds;
            _bPressed = true;
            _stopwatch.Reset();
        }
    }
}
