using CrazyPandaTestTask.Time;
using CrazyPandaTestTask.Tools;
using CrazyPandaTestTask.UI;
using UnityEngine;

namespace Installers
{
	public class MainTimeController
	{
		public MainTimeController(IWritableTimeProvider mainTimeProvider, ITimeScaleView view, Range timeRange)
		{
			Debug.Log("Time Range:  " + timeRange.Min + timeRange.Max);
			
			view.Init(timeRange, 1);
			view.ChangeInputEvent += mainTimeProvider.ChangeTimeScale;
			
			Debug.Log(mainTimeProvider.GetHashCode());
		}
	}
}