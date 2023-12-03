using System;

namespace CrazyPandaTestTask
{
	public class TimeProviderDecorator : ITimeProviderDecorator, IWritableTimeProvider
	{
		public float DeltaTime => OriginProvider.DeltaTime * DecoratorScale;
		public float FixedDeltaTime => OriginProvider.DeltaTime * DecoratorScale;
		public float TimeScale => OriginProvider.TimeScale * DecoratorScale;
		public float DecoratorScale { get; private set; }
		public ITimeProvider OriginProvider { get; set; }

		public event Action<float, float> ChangeTimeScaleEvent;

		public TimeProviderDecorator(ITimeProvider originProvider)
		{
			DecoratorScale = originProvider.TimeScale;
			OriginProvider = originProvider;
		}

		public void ChangeTimeScale(float newTimeScale)
		{
			float previousScale = DecoratorScale;
			DecoratorScale = newTimeScale;
			
			ChangeTimeScaleEvent?.Invoke(previousScale, DecoratorScale);
		}
	}
}