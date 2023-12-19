using UnityEngine;

namespace Bullet
{
	public class BulletDestroyer : MonoBehaviour
	{
		private void OnCollisionEnter2D(Collision2D col)
		{
			TryDestroyBullet(col.collider);
		}

		private void OnTriggerEnter2D(Collider2D col)
		{
			TryDestroyBullet(col);
		}

		private static void TryDestroyBullet(Collider2D col)
		{
			if (col.transform.TryGetComponent(out IBullet bullet))
				bullet.DestroyBullet();
		}
	}
}