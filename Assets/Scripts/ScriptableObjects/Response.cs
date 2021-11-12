using System;
using UnityEngine;
public enum ResponseValue {yes, no, none}
public enum ResponseType {truePositive, trueNegative, falsePositive, falseNegative, none}

[CreateAssetMenu] [Serializable]
public class Response : ScriptableObject
{
    public ResponseValue response;
    public float confidence;
    public int responseTime;
    public ResponseType responseType;
}
