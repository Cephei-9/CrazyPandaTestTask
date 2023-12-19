using Infrastructure.AssetCofig;
using Infrastructure.StaticData;
using Input;
using UI.Infrastructure;
using UnityEngine.SceneManagement;
using Zenject;

namespace Installers
{
	public class GameBootstrapInstaller : MonoInstaller<GameBootstrapInstaller>, IInitializable
	{
		private const int NEXT_SCENE = 1;
		
		public DataConfig DataConfig;
		public AssetConfig AssetConfig;

		public override void InstallBindings()
		{
			BindStandAloneInput();
			BindDataConfig();
			BindAssetConfig();
			BindGameBootstrapInstaller();
			BindUI();
		}

		private void BindUI()
		{
			Container.BindInterfacesTo<UIFactory>().AsSingle();
			Container.BindInterfacesTo<UIService>().AsSingle();
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