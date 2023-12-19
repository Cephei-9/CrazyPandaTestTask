using UnityEngine;

namespace Chrono
{
	public interface IChronoObject
	{
		Vector2 Position { get; }
		
		void EnterArea(ChronoAreaProvider areaProvider);

		void ExitArea(ChronoAreaProvider areaProvider);
	}
}