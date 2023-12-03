using System;
using UnityEngine;

namespace DefaultNamespace.Factory
{
	// I wanted to write a normal factory with Pool, AssetProvider and StaticDataServices, but I didn't have enough time,
	// so I quickly threw this together
	
	public class TestFactory : MonoBehaviour, IBulletFactory
	{
		[SerializeField]
		private BulletConfigs BulletConfigs;

		public IBullet GetBullet(BulletType type, Vector3 position, Quaternion rotation, Transform parent)
		{
			InstantiateData instantiateData = new(position, rotation, parent);

			return type switch
			{
				BulletType.Simple => CreateBullet(BulletConfigs.SimpleBullet, instantiateData),
				BulletType.Ghost => CreateBullet(BulletConfigs.GhostBullet, instantiateData),
				BulletType.Invert => CreateBullet(BulletConfigs.InvertBullet, instantiateData),
				BulletType.Chaotic => CreateBullet(BulletConfigs.ChaoticBullet, instantiateData),
				_ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
			};
		}

		private IBullet CreateBullet<TBullet, TData>(BulletConfig<TBullet, TData> config,
			InstantiateData instantiateData) where TBullet : MonoBehaviour, IInitializeBullet<TData>
		{
			TBullet newBullet = Instantiate(config.Prefab, instantiateData.Position, instantiateData.Rotation,
				instantiateData.Parent);
			newBullet.InitData(config.Data);

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