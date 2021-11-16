using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeedbackPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _feedbackText;
    [SerializeField] private ExperimentStage _experimentStage;
    [SerializeField] private Stage _stage;
    
    public void StatisticsAvailable(Statistics statistics)
    {
        if (_stage == _experimentStage.stage)
        {
            GetComponent<PanelDimmer>().Show();
            _feedbackText.text = "\n \n \n \n Detected Hits:"
                 + statistics.truePositiveCount
                 + "\n False Alarms : "
                 + statistics.falsePositiveCount
                 + "\n Correct Rejections : "
                 + statistics.trueNegativeCount
                 + "\n Misses : "
                 + statistics.falseNegativeCount
                 + "\n Mean confidence rating : "
                 + statistics.meanConfidenceRating 
                 + " seconds";    
        }
    }

    public void OkButtonPressed()
    {
        _experimentStage.stage = Stage.offline; //switch to offline
    }
}
