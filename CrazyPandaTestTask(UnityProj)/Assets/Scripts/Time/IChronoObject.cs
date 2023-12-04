using UnityEngine;

namespace CrazyPandaTestTask
{
	public interface IChronoObject
	{
		Vector2 Position { get; }
		
		void EnterArea(ChronoAreaProvider areaProvider);

		void ExitArea(ChronoAreaProvider areaProvider);
	}
}