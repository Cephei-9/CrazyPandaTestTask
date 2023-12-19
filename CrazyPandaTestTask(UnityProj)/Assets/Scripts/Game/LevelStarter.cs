using UI.Infrastructure;
using Zenject;

namespace CrazyPandaTestTask.Game
{
	public class LevelStarter : IInitializable
	{
		private readonly IUIService _uiService;
		private readonly IUIControllersFactory _levelControllersFactory;

		public LevelStarter(IUIService uiService, IUIControllersFactory levelControllersFactory)
		{
			_uiService = uiService;
			_levelControllersFactory = levelControllersFactory;
		}
		
		public void Initialize()
		{
			_uiService.UpdateControllersFactory(_levelControllersFactory);
			_uiService.OpenHud();
		}
	}
}