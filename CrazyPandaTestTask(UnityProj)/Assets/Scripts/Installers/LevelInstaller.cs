using CrazyPandaTestTask.Factory;
using CrazyPandaTestTask.Game;
using CrazyPandaTestTask.Time;
using CrazyPandaTestTask.Tools;
using CrazyPandaTestTask.UI;
using UI;
using UI.Infrastructure;
using UnityEngine;
using UnityEngine.Serialization;
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
			BindAreasFactory();
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

		private void BindAreasFactory()
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