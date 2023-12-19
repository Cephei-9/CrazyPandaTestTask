using System;
using UnityEngine;
using UnityEngine.UIElements;
using Range = CrazyPandaTestTask.Tools.Range;

namespace CrazyPandaTestTask.Time
{
	public class InvertTimeProvider : TimeProviderDecoratorBase
	{
		[Serializable]
		public class Data
		{
			public bool UseRoot;
			public float InvertFactor = 0.5f;
			public Range MinMaxValue = new Range(0, float.MaxValue); 
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
			float invertedTimeScale = 1 / timeScale - 1;
			float rootValue = GetRoot(invertedTimeScale);
			float resultScale = 1 + rootValue * _data.InvertFactor;
			float clampedScale = _data.MinMaxValue.Clamp(resultScale);
			
			DecoratorScale = clampedScale / timeScale;
		}

		private float GetRoot(float value)
		{
			if (_data.UseRoot == false)
				return value;
			
			float abs = Math.Abs(value);
			float sign = value < 0 ? -1 : 1;

			return Mathf.Sqrt(abs) * sign;
		}
	}
}