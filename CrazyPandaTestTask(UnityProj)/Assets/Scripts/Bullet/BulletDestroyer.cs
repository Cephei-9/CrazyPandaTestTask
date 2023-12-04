using System;
using UnityEngine;

namespace DefaultNamespace
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