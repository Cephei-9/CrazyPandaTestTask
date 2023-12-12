using CrazyPandaTestTask.Factory;
using CrazyPandaTestTask.Input;
using UnityEngine.SceneManagement;
using Zenject;

namespace Installers
{
	public class GameBootstrapInstaller : MonoInstaller<GameBootstrapInstaller>, IInitializable
	{
		private const int NEXT_SCENE = 1;
		
		public BulletConfigs BulletConfigs;
		
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<TestFactory>().AsSingle();
			Container.Bind<BulletConfigs>().FromInstance(BulletConfigs).AsSingle();
			Container.BindInterfacesTo<StandAloneInput>().AsSingle();

			Container.BindInterfacesTo<GameBootstrapInstaller>().FromInstance(this);
		}

		public void Initialize()
		{
			SceneManager.LoadScene(NEXT_SCENE);
		}
	}
}