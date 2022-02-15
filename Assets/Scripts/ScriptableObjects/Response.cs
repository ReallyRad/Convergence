using System;
using UnityEngine;
public enum ResponseValue {yes, no, none}
public enum ResponseType {truePositive, trueNegative, falsePositive, falseNegative, none}

[CreateAssetMenu] [Serializable]
public class Response : ScriptableObject
{
    public ResponseValue response;
    public Stage experimentStage;
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
        {
            Debug.Log("response was true positive");            
            return ResponseType.truePositive;
        }

        if ((response == ResponseValue.no || response == ResponseValue.none) && stimulusLevel == 1f)
        {
            Debug.Log("response was false negative");            
            return ResponseType.falseNegative;
        }

        if (response == ResponseValue.yes && stimulusLevel != 1f)
        {
            Debug.Log(("response was false positive"));
            return ResponseType.falsePositive;
        } 
        
        Debug.Log(("response was true negative"));
        return ResponseType.trueNegative;
    }
}
