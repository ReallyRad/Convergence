using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stage
{
    online,
    offline
};

[CreateAssetMenu]
public class ExperimentStage : ScriptableObject
{
    public Stage stage;
}
