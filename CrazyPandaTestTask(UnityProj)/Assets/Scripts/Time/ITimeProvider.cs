using System;

namespace CrazyPandaTestTask.Time
{
	public interface ITimeProvider
	{
		public static ITimeProvider Default => new DefaultTimeScaleProvider();

		public static ITimeProvider Unscaled => new UnscaledTimeScaleProvider();
		
		float DeltaTime { get; }
		float FixedDeltaTime { get; }
		float TimeScale { get; }
		event Action<float, float> ChangeTimeScaleEvent;
	}

	public interface IWritableTimeProvider : ITimeProvider
	{
		public new static IWritableTimeProvider Default => new DefaultTimeScaleProvider();
		
		void ChangeTimeScale(float newTimeScale);
	}

	public interface ITimeProviderDecorator : ITimeProvider
	{
		float DecoratorScale { get; }
		ITimeProvider OriginProvider { get; }
	}
}