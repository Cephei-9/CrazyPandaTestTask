using System;
using Range = Tools.Range;

namespace UI.Elements
{
	public interface ITimeScaleView
	{
		float Value { get; }
		event Action<float> ChangeInputEvent;

		void Init(Range range, float startValue);

		void ShowValue(float value);

		void ProvideInput();
	}
}