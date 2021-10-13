using UnityEngine;
public enum ResponseValue {yes, no, none}

[CreateAssetMenu]
public class Response : ScriptableObject
{
    public ResponseValue response;
    public float confidence;

    private void Awake()
    {
        response = ResponseValue.none;
        confidence = 0;
    }
}
