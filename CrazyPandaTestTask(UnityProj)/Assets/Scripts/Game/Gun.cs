using System;
using CrazyPandaTestTask.Bullet;
using CrazyPandaTestTask.Factory;
using CrazyPandaTestTask.Input;
using CrazyPandaTestTask.Time;
using CrazyPandaTestTask.UI;
using UnityEngine;
using Range = CrazyPandaTestTask.Tools.Range;

namespace CrazyPandaTestTask.Game
{
	public class Gun : MonoBehaviour
	{
		[Serializable]
		public class Data
		{
			public Range TimeScaleRange = new(0.5f, 2);
			public float Force = 10;
		}
		
		// These constants could be put in the date
		private const float DEFAULT_TIME_SCALE = 1;
		private const BulletType START_BULLET = BulletType.Simple;

		[SerializeField]
		private Transform FirePoint;

		private Data _data;
		
		private GunInput _input;
		private IBulletFactory _bulletFactory;
		private IBulletSelectorView _selectorView;
		private ITimeScaleView _timeScaleView;
		
		private BulletType _currentBulletType;
		private TimeProviderDecorator _timeProvider;

		public void Init(Data data, ITimeProvider originProvider, GunInput input, IBulletFactory bulletFactory,
			IBulletSelectorView selectorView, ITimeScaleView timeScaleView)
		{
			_data = data;
			_input = input;
			_bulletFactory = bulletFactory;
			_selectorView = selectorView;
			_timeScaleView = timeScaleView;

			_timeProvider = new TimeProviderDecorator(originProvider);
			
			_timeScaleView.Init(_data.TimeScaleRange, DEFAULT_TIME_SCALE);
			_timeScaleView.ChangeInputEvent += UpdateTimeScale;
			
			_selectorView.ShowBullet(START_BULLET);
		}

		private void Update()
		{
			if (_input.ChangeBullet)
				ChangeBullet();
			if (_input.Shoot)
				Shoot();
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

			_selectorView.ShowBullet(_currentBulletType);
		}

		private void UpdateTimeScale(float newTimeScale)
		{
			_timeProvider.ChangeTimeScale(newTimeScale);
		}
	}
}