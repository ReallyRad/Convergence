using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    [SerializeField] private ExperimentStage _experimentStage;
    [SerializeField] private GameObject _onlineText;
    [SerializeField] private GameObject _offlineText;
    public void PracticeFinished()
    {
        GetComponent<PanelDimmer>().Show();
        _onlineText.SetActive(_experimentStage.stage == Stage.online);
        _offlineText.SetActive(_experimentStage.stage == Stage.offline);
    }
}
