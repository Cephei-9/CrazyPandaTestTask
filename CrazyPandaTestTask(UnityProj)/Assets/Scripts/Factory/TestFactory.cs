using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace DefaultNamespace.Factory
{
	// I wanted to write a normal factory with Pool, AssetProvider and StaticDataServices, but I didn't have enough time,
	// so I quickly threw this together
	
	public class TestFactory : IBulletFactory
	{
		private BulletConfigs _bulletConfigs;

		public TestFactory(BulletConfigs bulletConfigs)
		{
			_bulletConfigs = bulletConfigs;
		}

		public IBullet GetBullet(BulletType type, Vector3 position, Quaternion rotation, Transform parent)
		{
			InstantiateData instantiateData = new(position, rotation, parent);

			return type switch
			{
				BulletType.Simple => CreateBullet(_bulletConfigs.SimpleBullet, instantiateData),
				BulletType.Ghost => CreateBullet(_bulletConfigs.GhostBullet, instantiateData),
				BulletType.Invert => CreateBullet(_bulletConfigs.InvertBullet, instantiateData),
				BulletType.Chaotic => CreateBullet(_bulletConfigs.ChaoticBullet, instantiateData),
				_ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
			};
		}

		private IBullet CreateBullet<TBullet, TData>(BulletConfig<TBullet, TData> config,
			InstantiateData instantiateData) where TBullet : MonoBehaviour, IInitializeBullet<TData>
		{
			TBullet newBullet = Object.Instantiate(config.Prefab, instantiateData.Position, instantiateData.Rotation,
				instantiateData.Parent);
			
			newBullet.InitData(config.Data);
			newBullet.DestroyEvent += () => Object.Destroy(newBullet.gameObject);

			return newBullet;
		}

		private class InstantiateData
		{
			public readonly Transform Parent;
			public readonly Vector3 Position;
			public readonly Quaternion Rotation;

			public InstantiateData(Vector3 position, Quaternion rotation, Transform parent)
			{
				Position = position;
				Rotation = rotation;
				Parent = parent;
			}
		}
	}
}