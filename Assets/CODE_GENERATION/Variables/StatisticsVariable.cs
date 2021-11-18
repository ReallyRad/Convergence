using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
	[System.Serializable]
	public class StatisticsEvent : UnityEvent<Statistics> { }

	[CreateAssetMenu(
	    fileName = "StatisticsVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Statistics",
	    order = 120)]
	public class StatisticsVariable : BaseVariable<Statistics, StatisticsEvent>
	{
	}
}