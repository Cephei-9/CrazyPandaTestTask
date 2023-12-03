using System;
using UnityEngine;

namespace CrazyPandaTestTask
{
	public static class MainTimeProvider
	{
		public static float DeltaTime => Time.deltaTime;
		public static float FixedDeltaTime => Time.fixedDeltaTime;
		public static float TimeScale => Time.timeScale;
		public static float UnscaledDeltaTime => Time.unscaledDeltaTime;
		public static float UnscaledFixedDeltaTime => Time.fixedUnscaledDeltaTime;
		
		public static event Action<float, float> ChangeTimeScaleEvent;

		public static void ChangeTimeScale(float newScale)
		{
			float previousScale = Time.timeScale;
			ChangeTimeScaleEvent?.Invoke(previousScale, Time.timeScale = newScale);
		}
	}
}