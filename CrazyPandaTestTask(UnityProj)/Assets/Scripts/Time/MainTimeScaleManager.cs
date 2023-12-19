using Infrastructure.StaticData;
using Time.Infrastructure;
using Tools;

namespace Time
{
	public class MainTimeScaleManager
	{
		private readonly IWritableTimeProvider _mainTimeProvider;

		public Range TimeRange { get; }
		public float TimeScale => _mainTimeProvider.TimeScale;

		public MainTimeScaleManager(IStaticData staticData, IWritableTimeProvider mainTimeProvider)
		{
			_mainTimeProvider = mainTimeProvider;
			TimeRange = staticData.MainTimeScaleRange;
		}
		
		public void ChangeTimeScale(float newValue)
		{
			_mainTimeProvider.ChangeTimeScale(newValue);	
		}
	}
}