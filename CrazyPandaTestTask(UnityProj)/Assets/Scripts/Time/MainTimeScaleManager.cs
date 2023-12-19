using CrazyPandaTestTask.Time;
using CrazyPandaTestTask.Tools;
using CrazyPandaTestTask.UI;
using Infrostructure;
using UnityEngine;

namespace Installers
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