using System;
using TMPro;
using Tools;
using UnityEngine;
using UnityEngine.UI;
using Range = Tools.Range;

namespace UI.Elements
{
	public class TimeScaleView : MonoBehaviour, ITimeScaleView
	{
		[SerializeField]
		private Slider Slider;
		[SerializeField]
		private TextMeshProUGUI MinText;
		[SerializeField]
		private TextMeshProUGUI MaxText;
		
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

			MinText.text = range.Min.ToString("0.#");
			MaxText.text = range.Max.ToString("0.#");

			SetTimeScaleValue(startValue);
		}

		public void ShowValue(float value)
		{
			SetTimeScaleValue(value);
			Slider.interactable = false;
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
			if(Value.IsEquals(newValue))
				return;
			
			Value = newValue;
			ChangeInputEvent?.Invoke(Value);
		}
	}
}