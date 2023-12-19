namespace Time.Infrastructure
{
	public class TimeProviderDecorator : TimeProviderDecoratorBase, IWritableTimeProvider
	{
		public TimeProviderDecorator(ITimeProvider originProvider)
		{
			DecoratorScale = originProvider.TimeScale;
			OriginProvider = originProvider;

			OriginProvider.ChangeTimeScaleEvent += OnOriginChangeTimeScaleEvent;
		}

		public void ChangeTimeScale(float newTimeScale)
		{
			float previousScale = DecoratorScale;
			DecoratorScale = newTimeScale;
			
			InvokeChangeTimeScaleEvent(previousScale, DecoratorScale);
		}
	}
}