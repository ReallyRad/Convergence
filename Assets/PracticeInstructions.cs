using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PracticeInstructions : MonoBehaviour
{
    [SerializeField] private Text _onlineInstructions;
    [SerializeField] private Text _offlineInstructions;
    [SerializeField] private ExperimentStage _experimentStage;
    // Start is called before the first frame update

    public void Show(bool show)
    {
        GetComponent<PanelDimmer>().Show(show, 1f);
        _onlineInstructions.gameObject.SetActive(_experimentStage.stage == Stage.online);
        _offlineInstructions.gameObject.SetActive(_experimentStage.stage == Stage.offline);
    }
}
