using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public Stage stage;
    [SerializeField] private ExperimentStage _experimentStage;
    
    public void IntroFinished(ExperimentStage experimentStage)
    {
        if (stage == experimentStage.stage)
        {
            GetComponent<PanelDimmer>().Show();
        }
    }

    public void AudioFinished()
    {
        if(_experimentStage.stage == stage) GetComponent<PanelDimmer>().Hide();
    }
}
