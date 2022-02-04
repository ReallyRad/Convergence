using System;
using UnityEngine;
public enum ResponseValue {yes, no, none}
public enum ResponseType {truePositive, trueNegative, falsePositive, falseNegative, none}

[CreateAssetMenu] [Serializable]
public class Response : ScriptableObject
{
    public ResponseValue response;
    public Stage _experimentStage;
    public ResponseType responseType;
    public float confidence;
    public int responseTime;
    public float currentVolume;

    public void SetResponseValueTypes(float stimulusVolume)
    {
        responseType = ClassifyResponseTypes(response, stimulusVolume);
    }
    
    private ResponseType ClassifyResponseTypes(ResponseValue response, float stimulusLevel)
    {
        if (response == ResponseValue.yes && stimulusLevel == 1f)  
            return ResponseType.truePositive;
        if ((response == ResponseValue.no || response == ResponseValue.none) && stimulusLevel == 1f)
            return ResponseType.falseNegative;
        if (response == ResponseValue.yes && stimulusLevel != 1f) 
            return ResponseType.falsePositive;
        
        return ResponseType.trueNegative;
    }
}
