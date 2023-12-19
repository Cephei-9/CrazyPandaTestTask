using System;
using Engine;
using Time.Infrastructure;
using Tools;
using UnityEngine;
using Random = UnityEngine.Random;
using Range = Tools.Range;

namespace Bullet.BulletComponents
{
	// Class can work with any Engin implementation. This is where the meaning of making the engine an abstraction is revealed
	
	public class ChaoticForce : IUpdatable
	{
		[Serializable]
		public class Data
		{
			public Range TimeRange = new Range(1, 3);
			public Range ForceRange = new Range(1, 3);
			[Tooltip("Angle from the Y-axis describing the area where the force can be applied")]
			public float AreaAngle = 45;
		}

		private Data _data;
		private IChronoEngine _engine;
		private ITimeProvider _timeProvider;
		private Transform _transform;

		private float _targetTime;
		private float _timer;

		public ChaoticForce(Data data, IChronoEngine engine, ITimeProvider timeProvider, Transform transform)
		{
			_data = data;
			_engine = engine;
			_timeProvider = timeProvider;
			_transform = transform;
			
			ResetTimer();
		}

		public void UpdateWork()
		{
			_timer += _timeProvider.DeltaTime;

			if (_timer < _targetTime) 
				return;

			ResetTimer();
			AddForce();
		}

		private void AddForce()
		{
			float angle = Random.Range(-1 * _data.AreaAngle, _data.AreaAngle);
			Vector2 direction = Quaternion.AngleAxis(angle, Vector3.forward) * _transform.up;
			float force = _data.ForceRange.GetRandom();
			
			_engine.AddChronoForce(direction * force, ForceMode.VelocityChange);
		}

		private void ResetTimer()
		{
			_timer = 0;
			_targetTime = _data.TimeRange.GetRandom();
		}
	}
}