using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class Detection : MonoBehaviour
{
    [SerializeField] private ExperimentStage _experimentStage;
    [SerializeField] private Response _response;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject _answerGameObject;
    [SerializeField] private Button _OKButton;
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;
    [SerializeField] private Color _selectedColor; 
    [SerializeField] private Color _unselectedColor; 
        
    private Stopwatch _stopwatch;
    private bool _bPressed;
    
    private void Awake()
    {
        _stopwatch = new Stopwatch();
    }

    public void ReadyToShow()
    {
        GetComponent<PanelDimmer>().Show();
        _answerGameObject.GetComponent<PanelDimmer>().Hide();
        
        _OKButton.interactable = false;

        if (_experimentStage.stage == Stage.offline) _text.text ="Listen...";
            
        else if (_experimentStage.stage == Stage.online)  _text.text ="Listen...\n\n\n\n  Press \"B\" when you hear the melody";

        _response.response = ResponseValue.none;
        
        if (_experimentStage.stage == Stage.online)
        {
            _stopwatch.Start();
            Debug.Log("starting stopwatch");
            _bPressed = false;
        }
    }

    public void AudioFinished()
    {
        //
        if (_experimentStage.stage == Stage.offline)
        {
            _answerGameObject.GetComponent<PanelDimmer>().Show();
            _stopwatch.Start();
            _text.text = "";
        }
        else if (_experimentStage.stage == Stage.online)
        {
            GetComponent<PanelDimmer>().Hide();    
            if (_response.response == ResponseValue.none) //&& _experimentStage.stage == Stage.online)
            {
                _response.response = ResponseValue.no;
                _stopwatch.Stop();
                _stopwatch.Reset();
            }
        }
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.B)) 
        {
            //&& experimentStage.stage == Stage.online && stage == Stage.online))
            if (!_bPressed && _experimentStage.stage == Stage.online)
            {
                _bPressed = true;
                _stopwatch.Stop();
                Debug.Log("B pressed. Detection response time = " + _stopwatch.ElapsedMilliseconds);
                _text.text = " ";
                _response.response = ResponseValue.yes;
                _response.responseTime += (int) _stopwatch.ElapsedMilliseconds;
                _stopwatch.Reset();    
            
            }
            else if (_experimentStage.stage == Stage.offline) _yesButton.onClick.Invoke();
         
        }
        else if (Input.GetKeyUp(KeyCode.N))
        {
            if (_experimentStage.stage == Stage.offline)
            {
                _noButton.onClick.Invoke();
            }
        }
    }

    public void MelodyThere(bool there)
    {
        _OKButton.interactable = true;
        _response.experimentStage = Stage.offline; 
        if (there) _response.response = ResponseValue.yes;
        else _response.response = ResponseValue.no;
        if (there)
        {
            _yesButton.gameObject.GetComponent<Image>().color = _selectedColor;
            _noButton.gameObject.GetComponent<Image>().color = _unselectedColor;
        }
        else
        {
            _yesButton.gameObject.GetComponent<Image>().color = _unselectedColor;
            _noButton.gameObject.GetComponent<Image>().color = _selectedColor;
        }
    }
    
    public void OKButtonPressed()
    {
        _stopwatch.Stop();
        Debug.Log( "Time to answer melody detection :" + _stopwatch.ElapsedMilliseconds);
        _response.responseTime = (int) _stopwatch.ElapsedMilliseconds;
        _stopwatch.Reset();
        GetComponent<PanelDimmer>().Hide();
    }
}
