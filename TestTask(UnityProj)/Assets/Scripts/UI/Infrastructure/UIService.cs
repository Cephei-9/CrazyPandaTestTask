using UI.Window;

namespace UI.Infrastructure
{
	public class UIService : IUIService
	{
		private readonly IUIFactory _uiFactory;
		private IUIControllersFactory _factory;

		public UIService(IUIFactory uiFactory)
		{
			_uiFactory = uiFactory;
		}

		// Update Controllers from current context
		public void UpdateControllersFactory(IUIControllersFactory factory)
		{
			_factory = factory;
		}
		
		public void OpenHud()
		{
			HudView hudView = _uiFactory.CreateHud();
			HudController hudController = _factory.GetController<HudController>();
			
			hudController.Open(hudView);
		}
	}
}