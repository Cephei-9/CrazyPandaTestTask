using Infrastructure.AssetCofig;
using UI.Window;
using UnityEngine;

namespace UI.Infrastructure
{
	public class UIFactory : IUIFactory
	{
		private readonly IAssetConfig _assetConfig;

		private GameObject _uiRoot;

		private GameObject UIRoot => _uiRoot ??= CreateUIRoot();

		public UIFactory(IAssetConfig assetConfig)
		{
			_assetConfig = assetConfig;
		}

		public HudView CreateHud()
		{
			return Object.Instantiate(_assetConfig.HudView, UIRoot.transform);
		}

		private GameObject CreateUIRoot()
		{
			return Object.Instantiate(_assetConfig.UIRoot);
		}
	}
}