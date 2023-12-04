using UnityEngine;

namespace CrazyPandaTestTask.Bullet
{
	public class BulletDestroyer : MonoBehaviour
	{
		private void OnCollisionEnter2D(Collision2D col)
		{
			if (col.transform.TryGetComponent(out IBullet bullet))
				bullet.DestroyBullet();
		}
	}
}