using System;
using CrazyPandaTestTask;
using DefaultNamespace.BulletComponents;
using UnityEngine;

namespace DefaultNamespace
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
		private ChronoObject ChronoObject;
		[SerializeField]
		private ColorTimeScaleView TimeScaleView;

		private PhysicsChronoEngine _engine;

		public override void Shoot(Vector2 velocity, ITimeProvider timeProvider)
		{
			TimeScaleView.Init(ChronoObject);
			ChronoObject.Init(timeProvider);

			// If I were using a Mono-component approach, it would be difficult to use non-Mono classes and configure
			// objects so conveniently
			InvertTimeProvider invertTimeProvider = new(_data.InvertData, ChronoObject);

			Rigidbody2D rb = GetComponent<Rigidbody2D>();
			_engine = new PhysicsChronoEngine(invertTimeProvider, timeProvider, _data.EngineData, rb);
			_engine.AddChronoForce(velocity * _data.ShootVelocityMultiply, ForceMode.VelocityChange);

			base.Shoot(velocity, timeProvider);
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
	}
}