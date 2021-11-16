using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public sealed class StatisticsReference : BaseReference<Statistics, StatisticsVariable>
	{
	    public StatisticsReference() : base() { }
	    public StatisticsReference(Statistics value) : base(value) { }
	}
}