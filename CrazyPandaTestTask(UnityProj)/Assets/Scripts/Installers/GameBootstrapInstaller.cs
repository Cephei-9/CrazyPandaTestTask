using CrazyPandaTestTask.Factory;
using CrazyPandaTestTask.Input;
using Infrastructure;
using Infrostructure;
using UnityEngine.SceneManagement;
using Zenject;

namespace Installers
{
	public class GameBootstrapInstaller : MonoInstaller<GameBootstrapInstaller>, IInitializable
	{
		private const int NEXT_SCENE = 1;
		
		public BulletConfigs BulletConfigs;
		
		public DataConfig DataConfig;
		public AssetConfig AssetConfig;

		public override void InstallBindings()
		{
			BindTestFactory();
			BindBulletConfigs();
			BindStandAloneInput();
			BindDataConfig();
			BindAssetConfig();
			BindGameBootstrapInstaller();
		}

		private void BindTestFactory()
		{
			Container.BindInterfacesTo<TestFactory>().AsSingle();
		}

		private void BindBulletConfigs()
		{
			Container.Bind<BulletConfigs>().FromInstance(BulletConfigs).AsSingle();
		}

		private void BindStandAloneInput()
		{
			Container.BindInterfacesTo<StandAloneInput>().AsSingle();
		}

		private void BindDataConfig()
		{
			Container.Bind<IStaticData>().To<DataConfig>().FromInstance(DataConfig).AsSingle();
		}

		private void BindAssetConfig()
		{
			Container.BindInterfacesTo<AssetConfig>().FromInstance(AssetConfig).AsSingle();
		}

		private void BindGameBootstrapInstaller()
		{
			Container.BindInterfacesTo<GameBootstrapInstaller>().FromInstance(this);
		}

		public void Initialize()
		{
			SceneManager.LoadScene(NEXT_SCENE);
		}
	}
}