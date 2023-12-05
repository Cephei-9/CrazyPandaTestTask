using UnityEngine;

namespace CrazyPandaTestTask.ChronoArea
{
	public interface IChronoObject
	{
		Vector2 Position { get; }
		
		void EnterArea(ChronoAreaProvider areaProvider);

		void ExitArea(ChronoAreaProvider areaProvider);
	}
}