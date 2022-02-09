using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PracticeInstructions : MonoBehaviour
{
    [SerializeField] private TMP_Text _onlineInstructions;
    [SerializeField] private TMP_Text _offlineInstructions;
    [SerializeField] private ExperimentStage _experimentStage;
    
    private void Show(bool show)
    {
        GetComponent<PanelDimmer>().Show(show, 1f);
        _onlineInstructions.gameObject.SetActive(_experimentStage.stage == Stage.online);
        _offlineInstructions.gameObject.SetActive(_experimentStage.stage == Stage.offline);
    }

    public void FeedbackOKButtonPressed() //TODO allow switching order of online and offline
    {
        if (_experimentStage.stage == Stage.online)
        {
            Show(true);
        }
        else if (_experimentStage.stage == Stage.offline)
        {
        }
    }
    
}
