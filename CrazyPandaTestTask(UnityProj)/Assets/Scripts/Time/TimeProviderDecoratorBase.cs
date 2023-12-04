using System;

namespace CrazyPandaTestTask.Time
{
	public abstract class TimeProviderDecoratorBase : ITimeProviderDecorator, IDisposable
	{
		public float DeltaTime => OriginProvider.DeltaTime * DecoratorScale;
		public float FixedDeltaTime => OriginProvider.DeltaTime * DecoratorScale;
		public float TimeScale => OriginProvider.TimeScale * DecoratorScale;
		public float DecoratorScale { get; protected set; }
		public ITimeProvider OriginProvider { get; protected set; }

		public event Action<float, float> ChangeTimeScaleEvent;

		public void Dispose()
		{
			if (OriginProvider != null)
				OriginProvider.ChangeTimeScaleEvent -= OnOriginChangeTimeScaleEvent;
		}

		protected virtual void InvokeChangeTimeScaleEvent(float previousScale, float newScale)
		{
			ChangeTimeScaleEvent?.Invoke(previousScale, newScale);
		}

		protected virtual void OnOriginChangeTimeScaleEvent(float previousScale, float newScale)
		{
			InvokeChangeTimeScaleEvent(previousScale, newScale);
		}
	}
}