using System;
using UnityEngine;
public enum ResponseValue {yes, no, none}

[CreateAssetMenu]
public class Response : ScriptableObject
{
    public ResponseValue response;
    public float confidence;

    private void OnEnable()
    {
        response = ResponseValue.none;
        confidence = 0.5f;
    }
}
