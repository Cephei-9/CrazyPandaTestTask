namespace UI.Infrastructure
{
	// Access service to control UI things (windows, popups, elements and other)
	public interface IUIService
	{
		void OpenHud();

		void UpdateControllersFactory(IUIControllersFactory factory);
	}
}