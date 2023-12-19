using System;

namespace Time.Infrastructure
{
	public class DefaultTimeScaleProvider : IWritableTimeProvider, IDisposable
	{
		public float DeltaTime => MainTimeProvider.DeltaTime;
		public float FixedDeltaTime => MainTimeProvider.FixedDeltaTime;
		public float TimeScale => MainTimeProvider.TimeScale;
		
		public event Action<float, float> ChangeTimeScaleEvent;

		public DefaultTimeScaleProvider()
		{
			MainTimeProvider.ChangeTimeScaleEvent += InvokeChangeTimeScale;
		}

		public void ChangeTimeScale(float newTimeScale)
		{
			MainTimeProvider.ChangeTimeScale(newTimeScale);
		}

		private void InvokeChangeTimeScale(float previousScale, float newScale)
		{
			ChangeTimeScaleEvent?.Invoke(previousScale, newScale);
		}

		public void Dispose()
		{
			MainTimeProvider.ChangeTimeScaleEvent -= InvokeChangeTimeScale;
		}
	}
}