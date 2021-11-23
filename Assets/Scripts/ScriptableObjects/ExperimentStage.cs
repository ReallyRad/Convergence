using System.Collections;
using System.Collections.Generic;
using ScriptableObjectArchitecture;
using UnityEngine;

[CreateAssetMenu]
public class ExperimentStage : ScriptableObject
{
    public bool practiceRound; //whether we are currently doing practice or actual testing
    public int trialCount; //the current count of trials done (whether trial or actual)
    public int practiceTrials; //the number of practice trials that should be performed
    public int numberOfTrials; //the number of actual trials that should be performed
    public int alwaysStimulusTrials; //the number of trials in which we must always playback stimulus
    public float perceptualAmbiguityThreshold; //the confidence threshold at which we will start sometimes playing back noise only
    public bool alwaysShowingStimulus;
}
