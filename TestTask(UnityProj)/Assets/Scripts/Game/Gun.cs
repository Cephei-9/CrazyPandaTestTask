using System;
using Bullet;
using Infrastructure.Factory;
using Input;
using Time.Infrastructure;
using UnityEngine;
using Range = Tools.Range;

namespace Game
{
	public class Gun : MonoBehaviour
	{
		[Serializable]
		public class Data
		{
			public Range TimeScaleRange = new(0.5f, 2);
			public float Force = 10;
		}
		
		public event Action<BulletType> ChangeBulletEvent;

		[SerializeField]
		private Transform FirePoint;

		private Data _data;
		
		private GunInput _input;
		private IBulletFactory _bulletFactory;
		
		private BulletType _currentBulletType;
		private TimeProviderDecorator _timeProvider;
		
		public Range TimeScaleRange => _data.TimeScaleRange;

		public float TimeScale => _timeProvider.TimeScale;
		public BulletType StartBullet => BulletType.Simple;

		public void Init(Data data, ITimeProvider originProvider, GunInput input, IBulletFactory bulletFactory)
		{
			_data = data;
			_input = input;
			_bulletFactory = bulletFactory;

			_timeProvider = new TimeProviderDecorator(originProvider);
		}

		private void Update()
		{
			if (_input.ChangeBullet)
				ChangeBullet();
			if (_input.Shoot)
				Shoot();
		}

		public void UpdateTimeScale(float newTimeScale)
		{
			_timeProvider.ChangeTimeScale(newTimeScale);
		}

		private void Shoot()
		{
			Quaternion rotation = Quaternion.LookRotation(FirePoint.forward, FirePoint.up);
			Vector2 bulletVelocity = FirePoint.up * _data.Force;

			IBullet newBullet = _bulletFactory.GetBullet(_currentBulletType, FirePoint.position, rotation, transform);
			newBullet.Shoot(bulletVelocity, _timeProvider);
		}

		private void ChangeBullet()
		{
			_currentBulletType++;
			if (_currentBulletType == BulletType.Max)
				_currentBulletType = 0;

			ChangeBulletEvent?.Invoke(_currentBulletType);
		}
	}
}