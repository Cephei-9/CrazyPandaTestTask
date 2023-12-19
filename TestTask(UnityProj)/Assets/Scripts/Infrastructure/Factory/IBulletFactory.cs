using Bullet;
using UnityEngine;

namespace Infrastructure.Factory
{
	public interface IBulletFactory
	{
		IBullet GetBullet(BulletType type, Vector3 position, Quaternion rotation, Transform parent);
	}
}