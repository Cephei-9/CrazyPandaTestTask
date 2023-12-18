using Chrono;
using Infrostructure;
using UnityEngine;

namespace CrazyPandaTestTask.Factory
{
	public class Factory : IAreaFactory
	{
		private readonly IAssetConfig _assetConfig;
		private readonly IStaticData _staticData;

		public Factory(IAssetConfig assetConfig, IStaticData staticData)
		{
			_assetConfig = assetConfig;
			_staticData = staticData;
		}
		
		public IChronoArea CreateArea(AreasType type, InstantiateData instantiateData)
		{
			ChronoArea chronoArea = Object.Instantiate(_assetConfig.ChronoAreaPrefab, instantiateData.Position,
				instantiateData.Rotation, instantiateData.Parent);
			chronoArea.InitData(_staticData.GetChronoAreaData(type));
			
			return chronoArea;
		}
	}
}