using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResponseData
{
    public ResponseValue onlineResponse;
    public ResponseType onlineResponseType;
    public ResponseValue offlineResponse;
    public ResponseType offlineResponseType;
    public float confidence;
    public int responseTime;
}
