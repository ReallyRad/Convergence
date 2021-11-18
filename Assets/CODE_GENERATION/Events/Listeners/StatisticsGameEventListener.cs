using UnityEngine;

namespace ScriptableObjectArchitecture
{
	[AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Statistics")]
	public sealed class StatisticsGameEventListener : BaseGameEventListener<Statistics, StatisticsGameEvent, StatisticsUnityEvent>
	{
	}
}