using System;
using CrazyPandaTestTask.Time;
using UnityEngine;

namespace CrazyPandaTestTask.Bullet.BulletComponents
{
	public class ColorTimeScaleView : MonoBehaviour
	{
		private enum ColorWorkMode
		{
			SetColor,
			Additive,
			Multiply
		}
		
		[SerializeField]
		private float MinTimeScaleValue = 0;
		[SerializeField]
		private float MaxTimeScaleValue = 2;
		[SerializeField]
		private Gradient Gradient;
		[SerializeField]
		private ColorWorkMode WorkMode;
		[Space]
		[SerializeField]
		private SpriteRenderer SpriteRenderer;
		
		private ITimeProvider _timeProvider;
		private Color _startColor;

		public void Init(ITimeProvider timeProvider)
		{
			_timeProvider = timeProvider;
			_startColor = SpriteRenderer.color;
			
			_timeProvider.ChangeTimeScaleEvent += OnChangeTimeScale;
		}

		private void OnDestroy()
		{
			if(_timeProvider != null)
				_timeProvider.ChangeTimeScaleEvent -= OnChangeTimeScale;
		}

		private void OnChangeTimeScale(float previousTimeScale, float newTimeScale)
		{
			float gradientPosition = Mathf.InverseLerp(MinTimeScaleValue, MaxTimeScaleValue, newTimeScale);
			Color color = Gradient.Evaluate(gradientPosition);

			ApplyNewColor(color);
		}

		private void ApplyNewColor(Color color)
		{
			switch (WorkMode)
			{
				case ColorWorkMode.SetColor:
					SpriteRenderer.color = color;
					break;
				case ColorWorkMode.Additive:
					SpriteRenderer.color = _startColor + color;
					break;
				case ColorWorkMode.Multiply:
					SpriteRenderer.color = _startColor * color;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}