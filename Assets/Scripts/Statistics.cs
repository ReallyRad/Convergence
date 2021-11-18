using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Statistics
{
	public int truePositiveCount;
	public int falsePositiveCount;
	public int trueNegativeCount;
	public int falseNegativeCount;
	public float meanReactionTime;
	public float meanConfidenceRating;
}	