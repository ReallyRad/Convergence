using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionCanvases : MonoBehaviour
{
    [SerializeField] private GameObject[] _introductionCanvases;
    private int _introductionCanvasesIndex;
    
    public void NextButton()
    {
        if (_introductionCanvasesIndex + 1 < _introductionCanvases.Length) //if we have not yet reached the last page
        {
            _introductionCanvases[_introductionCanvasesIndex + 1].GetComponent<PanelDimmer>().Show(); //show the next one
        }
        else
        {
            //start the experiment
        }
        _introductionCanvases[_introductionCanvasesIndex].GetComponent<PanelDimmer>().Hide();//hide the current one

        _introductionCanvasesIndex++;
    }
}
