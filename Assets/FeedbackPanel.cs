using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FeedbackPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _feedbackText;
    
    public void StatisticsAvailable(Statistics statistics)
    {
        _feedbackText.text = "\n \n \n \n Detected Hits:"
                             + statistics.truePositiveCount
                             + "\n False Alarms : "
                             + statistics.falsePositiveCount
                             + "\n Correct Rejections : "
                             + statistics.trueNegativeCount
                             + "\n Misses : "
                             + statistics.falseNegativeCount
                             + "\n Mean confidence rating : "
                             + statistics.meanConfidenceRating;
        GetComponent<PanelDimmer>().Show();
    }
}
