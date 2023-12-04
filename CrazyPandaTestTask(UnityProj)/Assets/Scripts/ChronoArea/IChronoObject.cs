using CrazyPandaTestTask.ChronoArea;
using UnityEngine;

namespace CrazyPandaTestTask.Time
{
	public interface IChronoObject
	{
		Vector2 Position { get; }
		
		void EnterArea(ChronoAreaProvider areaProvider);

		void ExitArea(ChronoAreaProvider areaProvider);
	}
}