using System;

namespace CrazyPandaTestTask.Time
{
	public interface ITimeProvider
	{
		private static ITimeProvider _mainProvider;

		// Main Game Time provider(separated from Unity Time)
		public static ITimeProvider Main => _mainProvider ?? new TimeProviderDecorator(Default);

		// Access to Unity time(if you don't want to respond to Main Time)
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

		public new static IWritableTimeProvider Main => (IWritableTimeProvider)ITimeProvider.Main; 
		
		void ChangeTimeScale(float newTimeScale);
	}

	public interface ITimeProviderDecorator : ITimeProvider
	{
		float DecoratorScale { get; }
		ITimeProvider OriginProvider { get; }
	}
}