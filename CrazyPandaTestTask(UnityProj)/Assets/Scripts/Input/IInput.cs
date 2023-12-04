namespace CrazyPandaTestTask.Input
{
	public interface IInput
	{
		GunInput RightGunInput { get; }
		GunInput LeftGunInput { get; }
		AreaChangeInput AreaChangeInput { get; }
	}
}