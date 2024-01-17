using Game;
using Infrastructure.Factory;
using Time;
using Time.Infrastructure;
using UI.Infrastructure;
using UI.Window;
using Zenject;

namespace Installers
{
	// Controller connecting view objects with game logic. If the hud would contain more logic, it would be moved to
	// sub-controllers, and the hud itself would get a factory of controllers and create them on opening and pass them
	// sub-views that would be taken from the hud view.
	
	public class LevelInstaller : MonoInstaller<LevelInstaller>
	{
		public LevelContext LevelContext;
		
		public override void InstallBindings()
		{
			BindTime();
			BindTimeController();
			BindFactory();
			BindLevelContext();
			BindUIControllers();
		}

		private void BindUIControllers()
		{
			Container.BindInterfacesTo<UIControllersFactory>().AsSingle();
			
			Container.Bind<HudController>().AsTransient();
		}
		
		private void BindLevelContext()
		{
			Container.Bind<LevelContext>().FromInstance(LevelContext);
			Container.BindInterfacesTo<LevelStarter>().AsSingle().NonLazy();
			Container.Bind<GunsProvider>().AsSingle();
		}

		private void BindFactory()
		{
			Container.BindInterfacesTo<Factory>().AsSingle();
		}

		private void BindTimeController()
		{
			Container.Bind<MainTimeScaleManager>().AsSingle().NonLazy();
		}

		private void BindTime()
		{
			Container
				.Bind(typeof(ITimeProvider), typeof(IWritableTimeProvider))
				.To<TimeProviderDecorator>()
				.FromInstance(IWritableTimeProvider.Main).AsSingle();
		}
	}
}