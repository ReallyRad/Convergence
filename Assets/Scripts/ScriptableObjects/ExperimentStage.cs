using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

public enum Stage
{
    online,
    offline
};

[CreateAssetMenu]
public class ExperimentStage : ScriptableObject
{
    public Stage stage;
    public bool practiceRound;
    public int trialCount;
    public int mootTrials;
    public int numberOfTrials;
}
