using System;
using UnityEngine;
public enum ResponseValue {yes, no, none}

[CreateAssetMenu]
public class Response : ScriptableObject
{
    public ResponseValue response;
    public float confidence;
    public float responseTime;
    
    private void OnEnable()
    {
        response = ResponseValue.none;
        confidence = 0.5f;
        responseTime = 0;
    }
}
