using System;
using UnityEngine;

namespace DefaultNamespace.Factory
{
	public interface IBulletProvider<TSimpleBullet, TGhostBullet, TInvertBullet, TChaoticBullet>
	{
		TSimpleBullet GetSimpleBullet();

		TSimpleBullet GetGhostBullet();

		TSimpleBullet GetInvertBullet();

		TSimpleBullet GetChaoticBullet();
	}
	
	public interface IBulletProvider<TBullet>
	{
		TBullet GetSimpleBullet();

		TBullet GetGhostBullet();

		TBullet GetInvertBullet();

		TBullet GetChaoticBullet();

		TBullet GetByType(BulletType type)
		{
			return type switch
			{
				BulletType.Simple => GetSimpleBullet(),
				BulletType.Ghost => GetGhostBullet(),
				BulletType.Invert => GetInvertBullet(),
				BulletType.Chaotic => GetChaoticBullet(),
				_ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
			};
		}
	}

	public interface IAssetConfig
	{
		
	}

	[CreateAssetMenu(fileName = "AssetConfig", menuName = "AssetConfig", order = 51)]
	public class AssetConfig : ScriptableObject
	{
		
	}

	public interface IBulletFactory
	{
		IBullet GetBullet(BulletType type, Vector3 position, Quaternion rotation, Transform parent);
	}

	[Serializable]
	public class BulletConfig<TInitableBullet, TInitableData> where TInitableBullet : MonoBehaviour, IInitializeBullet<TInitableData>
	{
		public TInitableBullet Prefab;
		public TInitableData Data;
	}
}