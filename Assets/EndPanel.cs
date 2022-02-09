using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private ExperimentStage _experimentStage;
    
    public void Show() //TODO allow switching order of online and offline
    {
        if (_experimentStage.stage == Stage.online)
        {
            
        }
        else if (_experimentStage.stage == Stage.offline)
        {
            GetComponent<PanelDimmer>().Show();
        }
    }
}
