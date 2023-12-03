using System;
using CrazyPandaTestTask;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
	public class Gun : MonoBehaviour
	{
		public BulletData SimpleBulletData;
		public InvertBullet.Data InvertBulletData;
		
		public SimpleBullet SimpleBulletPrefab;
		public InvertBullet InvertBulletPrefab;

		[SerializeField]
		private Transform FirePoint;
		[SerializeField]
		private float Force = 10;

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				Quaternion rotation = Quaternion.LookRotation(FirePoint.forward);
				InvertBullet newBullet = Instantiate(InvertBulletPrefab, FirePoint.position, rotation, null);
				newBullet.InitData(InvertBulletData);
				newBullet.Shoot(FirePoint.up * Force, ITimeProvider.Default);
			}
		}
	}
}