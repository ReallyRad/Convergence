using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResponseData //data model used for retrieving from Firebase Database
{
    public ResponseValue response;
    public Stage experimentStage;
    public ResponseType responseType;
    public float confidence;
    public int responseTime;
    public float currentVolume;
}
