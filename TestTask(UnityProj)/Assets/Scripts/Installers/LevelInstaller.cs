using Game;
using Infrastructure.Factory;
using Time;
using Time.Infrastructure;
using UI.Infrastructure;
using UI.Window;
using Zenject;

namespace Installers
{
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
			Container.Bind<HudController>().AsSingle();
			
			Container.BindInterfacesTo<UIControllersFactory>().AsSingle();
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