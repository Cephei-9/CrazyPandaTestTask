using CrazyPandaTestTask.Bullet;
using UnityEngine;

namespace CrazyPandaTestTask.Factory
{
	public interface IBulletFactory
	{
		IBullet GetBullet(BulletType type, Vector3 position, Quaternion rotation, Transform parent);
	}
}