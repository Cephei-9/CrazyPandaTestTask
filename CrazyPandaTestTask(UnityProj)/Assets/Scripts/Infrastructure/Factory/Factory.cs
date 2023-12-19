using System;
using Bullet;
using Chrono;
using Infrastructure.AssetCofig;
using Infrastructure.StaticData;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.Factory
{
	public class Factory : IAreaFactory, IBulletFactory
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
			ChronoArea chronoArea = Object.Instantiate(_assetConfig.ChronoArea, instantiateData.Position,
				instantiateData.Rotation, instantiateData.Parent);
			chronoArea.InitData(_staticData.GetChronoAreaData(type));
			
			return chronoArea;
		}

		public IBullet GetBullet(BulletType type, Vector3 position, Quaternion rotation, Transform parent)
		{
			InstantiateData instantiateData = new(position, rotation, parent);

			return type switch
			{
				BulletType.Simple => CreateBullet(_assetConfig.SimpleBullet, _staticData.SimpleBulletData, instantiateData),
				BulletType.Ghost => CreateBullet(_assetConfig.GhostBullet, _staticData.GhostBulletData, instantiateData),
				BulletType.Invert => CreateBullet(_assetConfig.InvertBullet, _staticData.InvertBulletData, instantiateData),
				BulletType.Chaotic => CreateBullet(_assetConfig.ChaoticBullet, _staticData.ChaoticBulletData, instantiateData),
				_ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
			};
		}

		private IBullet CreateBullet<TBullet, TData>(TBullet prefab, TData bulletData, InstantiateData instantiateData) where TBullet : MonoBehaviour, IInitializeBullet<TData>
		{
			TBullet newBullet = Object.Instantiate(prefab, instantiateData.Position, instantiateData.Rotation,
				instantiateData.Parent);
			
			newBullet.InitData(bulletData);
			// The right thing to do would be to use a pool
			newBullet.DestroyEvent += () => Object.Destroy(newBullet.gameObject);

			return newBullet;
		}
	}
}