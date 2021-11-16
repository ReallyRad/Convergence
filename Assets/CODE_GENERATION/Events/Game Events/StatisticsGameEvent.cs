using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "StatisticsGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Statistics",
	    order = 120)]
	public sealed class StatisticsGameEvent : GameEventBase<Statistics>
	{
	}
}