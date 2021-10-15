using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

public class IntroductionCanvases : MonoBehaviour
{
    [SerializeField] private GameObject[] _introductionCanvases;
    [SerializeField] private GameEvent _introFinishedEvent;

    private int _introductionCanvasesIndex;
    
    public void NextButton()
    {
        if (_introductionCanvasesIndex + 1 < _introductionCanvases.Length) //if we have not yet reached the last page
        {
            _introductionCanvases[_introductionCanvasesIndex + 1].GetComponent<PanelDimmer>().Show(); //show the next one
        }
        else
        {
            _introFinishedEvent.Raise(); //start the experiment
        }
        _introductionCanvases[_introductionCanvasesIndex].GetComponent<PanelDimmer>().Hide();//hide the current one

        _introductionCanvasesIndex++;
    }
}
