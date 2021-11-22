using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

[CreateAssetMenu]
public class ExperimentStage : ScriptableObject
{
    public bool practiceRound;
    public int trialCount;
    public int mootTrials;
    public int numberOfTrials;
}
