using UnityEngine;

namespace DefaultNamespace.Factory
{
	public interface IBulletFactory
	{
		IBullet GetBullet(BulletType type, Vector3 position, Quaternion rotation, Transform parent);
	}
}