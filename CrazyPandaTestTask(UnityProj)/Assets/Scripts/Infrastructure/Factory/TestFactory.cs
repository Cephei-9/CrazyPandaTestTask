using System;
using CrazyPandaTestTask.Bullet;
using Infrostructure;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CrazyPandaTestTask.Factory
{
	// I wanted to write a normal factory with Pool, AssetProvider and StaticDataServices, but I didn't have enough time,
	// so I quickly threw this together
	
	public class TestFactory : IBulletFactory
	{
		private readonly IStaticData _staticData;
		private readonly IAssetConfig _assetConfig;

		public TestFactory(IStaticData staticData, IAssetConfig assetConfig)
		{
			_staticData = staticData;
			_assetConfig = assetConfig;
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