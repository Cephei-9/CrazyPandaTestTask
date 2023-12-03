using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
	public class Gun : MonoBehaviour
	{
		public Bullet BulletPrefab;

		[SerializeField]
		private Transform FirePoint;
		[SerializeField]
		private float Force = 10;

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				Quaternion rotation = Quaternion.LookRotation(FirePoint.forward);
				Bullet newBullet = Instantiate(BulletPrefab, FirePoint.position, rotation, null);
				newBullet.Shoot(FirePoint.up * Force);
			}
		}
	}
}