using System;
using Bullet.BulletComponents;
using Chrono;
using Engine;
using Time;
using Time.Infrastructure;
using UnityEngine;

namespace Bullet.ConcreteBullets
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class InvertBullet : BulletBase<InvertBullet.Data>
	{
		[Serializable]
		public class Data : BulletData
		{
			[Header("Invert Bullet")]
			public InvertTimeProvider.Data InvertData;
		}

		[SerializeField]
		private ChronoObjectCollider ChronoCollider;
		[SerializeField]
		private ColorTimeScaleView TimeScaleView;

		private PhysicsChronoEngine _engine;
		private ChronoObject _chronoObject;

		public override void Shoot(Vector2 velocity, ITimeProvider timeProvider)
		{
			_chronoObject = new ChronoObject(timeProvider, transform);
			ChronoCollider.Init(_chronoObject);

			// If I were using a Mono-component approach, it would be difficult to use non-Mono classes and configure
			// objects so conveniently
			InvertTimeProvider invertTimeProvider = new(_data.InvertData, _chronoObject);
			
			TimeScaleView.Init(invertTimeProvider);

			Rigidbody2D rb = GetComponent<Rigidbody2D>();
			_engine = new PhysicsChronoEngine(invertTimeProvider, timeProvider, _data.EngineData, rb);
			_engine.AddChronoForce(velocity * _data.ShootVelocityMultiply, ForceMode.VelocityChange);

			base.Shoot(velocity, invertTimeProvider);
		}

		protected override void OnBulletCollision(Collision2D col)
		{
			base.OnBulletCollision(col);
			
			_engine.OnCollision();
		}

		private void FixedUpdate()
		{
			_engine.UpdateWork();
		}

		private void Update()
		{
			_chronoObject.UpdateWork();
		}
	}
}