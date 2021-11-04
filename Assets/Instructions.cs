using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    [SerializeField] private Stage _stage;
    [SerializeField] private ExperimentStage _experimentStage;
    
    public void PracticeFinished()
    {
        if(_experimentStage.stage == _stage) GetComponent<PanelDimmer>().Show();
    }
}
