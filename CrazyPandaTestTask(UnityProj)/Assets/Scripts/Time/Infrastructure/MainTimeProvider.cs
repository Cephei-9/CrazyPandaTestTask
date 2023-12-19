using System;

namespace Time.Infrastructure
{
	public static class MainTimeProvider
	{
		public static float DeltaTime => UnityEngine.Time.deltaTime;
		public static float FixedDeltaTime => UnityEngine.Time.fixedDeltaTime;
		public static float TimeScale => UnityEngine.Time.timeScale;
		public static float UnscaledDeltaTime => UnityEngine.Time.unscaledDeltaTime;
		public static float UnscaledFixedDeltaTime => UnityEngine.Time.fixedUnscaledDeltaTime;
		
		public static event Action<float, float> ChangeTimeScaleEvent;

		public static void ChangeTimeScale(float newScale)
		{
			float previousScale = UnityEngine.Time.timeScale;
			ChangeTimeScaleEvent?.Invoke(previousScale, UnityEngine.Time.timeScale = newScale);
		}
	}
}