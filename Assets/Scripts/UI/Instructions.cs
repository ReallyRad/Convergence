using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    [SerializeField] private ExperimentStage _experimentStage;
    
    public void PracticeFinished()
    {
        GetComponent<PanelDimmer>().Show();
    }
}
