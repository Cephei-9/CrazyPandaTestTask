using System;
using CrazyPandaTestTask.Bullet;

namespace Bullet
{
	// Class like a Abstract Fabric but more generic and with useful integration with BulletType 
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
}