namespace CrazyPandaTestTask.Input
{
	// The input should operate not a bool but a button with different types of presses, and of course the input should
	// be multilayered from the lower view layers to the upper layers defining the logic of the input and the implementation
	
	public interface IInput
	{
		GunInput RightGunInput { get; }
		GunInput LeftGunInput { get; }
		AreaChangeInput AreaChangeInput { get; }
	}
}