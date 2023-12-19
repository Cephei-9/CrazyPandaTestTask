using System;
using UnityEngine;
using UnityEngine.UI;
using Range = CrazyPandaTestTask.Tools.Range;

namespace CrazyPandaTestTask.UI
{
	public class TimeScaleView : MonoBehaviour
	{
		[SerializeField]
		private Slider Slider;
		
		public float Value { get; private set; }
		
		public event Action<float> ChangeInputEvent;

		private void Awake()
		{
			Slider.onValueChanged.AddListener(OnValueChange);
		}

		public void Init(Range range, float startValue)
		{
			Slider.minValue = range.Min;
			Slider.maxValue = range.Max;

			SetTimeScaleValue(startValue);
		}

		public void ShowValue(float value)
		{
			Slider.interactable = false;
			SetTimeScaleValue(value);
		}

		public void ProvideInput()
		{
			Slider.interactable = true;
		}

		private void SetTimeScaleValue(float value)
		{
			Value = value;
			Slider.value = value;
		}

		private void OnValueChange(float newValue)
		{
			Value = newValue;
			ChangeInputEvent?.Invoke(Value);
		}
	}
}