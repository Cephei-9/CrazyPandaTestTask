namespace UI.Infrastructure
{
	public interface IUIService
	{
		void OpenHud();

		void UpdateControllersFactory(IUIControllersFactory factory);
	}
}