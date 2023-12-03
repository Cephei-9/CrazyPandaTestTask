using System;
using CrazyPandaTestTask;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace.BulletComponents
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

		public void Init(ITimeProvider timeProvider)
		{
			timeProvider.ChangeTimeScaleEvent += OnChangeTimeScale;
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
					SpriteRenderer.color += color;
					break;
				case ColorWorkMode.Multiply:
					SpriteRenderer.color *= color;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}