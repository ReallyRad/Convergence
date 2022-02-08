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
    // Start is called before the first frame update

    public void Show(bool show)
    {
        GetComponent<PanelDimmer>().Show(show, 1f);
        _onlineInstructions.gameObject.SetActive(_experimentStage.stage == Stage.online);
        _offlineInstructions.gameObject.SetActive(_experimentStage.stage == Stage.offline);
    }
}