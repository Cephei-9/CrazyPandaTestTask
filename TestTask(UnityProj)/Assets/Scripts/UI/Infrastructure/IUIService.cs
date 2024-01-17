namespace UI.Infrastructure
{
	// Access service to control UI things (windows, popups, elements and other). There would be a separate method for each
	// entity.
	
	public interface IUIService
	{
		void OpenHud();

		void UpdateControllersFactory(IUIControllersFactory factory);
	}
}