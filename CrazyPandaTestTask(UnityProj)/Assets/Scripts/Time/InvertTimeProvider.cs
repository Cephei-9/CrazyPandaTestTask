using System;

namespace CrazyPandaTestTask.Time
{
	public class InvertTimeProvider : TimeProviderDecoratorBase
	{
		[Serializable]
		public class Data
		{
			public float InvertFactor = 0.5f;
		}

		private Data _data;

		public InvertTimeProvider(Data data, ITimeProvider originProvider)
		{
			_data = data;
			OriginProvider = originProvider;
			
			OriginProvider.ChangeTimeScaleEvent += OnOriginChangeTimeScaleEvent;
			InvertTime(OriginProvider.TimeScale);
		}

		protected override void OnOriginChangeTimeScaleEvent(float previousScale, float newScale)
		{
			InvertTime(newScale);
			base.OnOriginChangeTimeScaleEvent(previousScale, newScale);
		}

		private void InvertTime(float timeScale)
		{
			float invertTimeScale = 1 + (1 / timeScale - 1) * _data.InvertFactor;
			DecoratorScale = invertTimeScale / timeScale;
		}
	}
}