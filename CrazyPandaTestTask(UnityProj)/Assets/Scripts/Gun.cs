using System;
using CrazyPandaTestTask;
using DefaultNamespace.Factory;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
	public class Gun : MonoBehaviour
	{
		public BulletType BulletType;
		public TestFactory Factory;

		[SerializeField]
		private Transform FirePoint;
		[SerializeField]
		private float Force = 10;

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				Quaternion rotation = Quaternion.LookRotation(FirePoint.forward, FirePoint.up);
				IBullet newBullet = Factory.GetBullet(BulletType, FirePoint.position, rotation, null);
				
				newBullet.Shoot(FirePoint.up * Force, ITimeProvider.Default);
			}
		}
	}
}