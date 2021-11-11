using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResponseData
{
    public ResponseValue response;
    public float confidence;
    public int responseTime;
    public ResponseType responseType;
}
