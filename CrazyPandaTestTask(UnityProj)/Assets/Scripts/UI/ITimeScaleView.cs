using System;

namespace DefaultNamespace.UI
{
	// View like MVC. Passive show and provide input
	
	public interface ITimeScaleView
	{
		float Value { get; }

		event Action<float> ChangeInputEvent;
		
		void Init(Range range, float startValue);

		void ShowValue(float value);

		void ProvideInput();
	}
}