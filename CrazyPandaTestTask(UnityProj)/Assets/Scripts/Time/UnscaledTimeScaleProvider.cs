using System;

namespace CrazyPandaTestTask.Time
{
	public class UnscaledTimeScaleProvider : ITimeProvider
	{
		public float DeltaTime => MainTimeProvider.UnscaledDeltaTime;
		public float FixedDeltaTime => MainTimeProvider.UnscaledFixedDeltaTime;
		public float TimeScale => MainTimeProvider.TimeScale;
		
		public event Action<float, float> ChangeTimeScaleEvent;
	}
}