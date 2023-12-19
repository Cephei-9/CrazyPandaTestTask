using System;

namespace Time.Infrastructure
{
	public class UnscaledTimeScaleProvider : ITimeProvider
	{
		public float DeltaTime => MainTimeProvider.UnscaledDeltaTime;
		public float FixedDeltaTime => MainTimeProvider.UnscaledFixedDeltaTime;
		public float TimeScale => MainTimeProvider.TimeScale;
		
		// Unscaled time should never change
		public event Action<float, float> ChangeTimeScaleEvent;
	}
}