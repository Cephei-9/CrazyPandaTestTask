using System;
using Chrono;
using CrazyPandaTestTask.Bullet.BulletComponents;
using CrazyPandaTestTask.Engine;
using CrazyPandaTestTask.Time;
using CrazyPandaTestTask.Tools;
using UnityEngine;

namespace CrazyPandaTestTask.Bullet
{
	// I did a nice bullet refactoring here
	
	[RequireComponent(typeof(Rigidbody2D))]
	public class ChaoticBullet : BulletBase<ChaoticBullet.Data>
	{
		[Serializable]
		public class Data : BulletData
		{
			[Header("Chaotic Bullet")]
			public ChaoticForce.Data ForceData;
		}
		
		[SerializeField]
		private ChronoObjectCollider ChronoCollider;

		private PhysicsChronoEngine _engine;
		private ChronoObject _chronoObject;
		private ChaoticForce _chaoticForce;

		private IUpdatable[] _updatable;
		private IFixedUpdatable[] _fixedUpdatable;

		public override void Shoot(Vector2 velocity, ITimeProvider timeProvider)
		{
			InitChrono(timeProvider);
			InitEngine(velocity, timeProvider);
			InitChaotic();
			InitUpdatable();
			
			base.Shoot(velocity, _chronoObject);
		}

		// Just to show how it should work with a large number of components
		// Another advantage of this non-Mono approach is that you can easily and very flexibly choose the order of
		// updating classes (although it is not used here).

		private void InitChrono(ITimeProvider timeProvider)
		{
			_chronoObject = new ChronoObject(timeProvider, transform);
			ChronoCollider.Init(_chronoObject);
		}

		private void InitEngine(Vector2 velocity, ITimeProvider timeProvider)
		{
			Rigidbody2D rb = GetComponent<Rigidbody2D>();
			_engine = new PhysicsChronoEngine(_chronoObject, timeProvider, _data.EngineData, rb);
			_engine.AddChronoForce(velocity * _data.ShootVelocityMultiply, ForceMode.VelocityChange);
		}

		private void InitChaotic()
		{
			_chaoticForce = new ChaoticForce(_data.ForceData, _engine, ITimeProvider.Default, transform);
		}

		private void InitUpdatable()
		{
			_updatable = new IUpdatable[]
			{
				_chaoticForce,
				_chronoObject
			};

			_fixedUpdatable = new IFixedUpdatable[]
			{
				_engine
			};
		}

		protected override void OnBulletCollision(Collision2D col)
		{
			base.OnBulletCollision(col);
			
			_engine.OnCollision();
		}

		private void FixedUpdate()
		{
			_fixedUpdatable.Update();
		}

		private void Update()
		{
			_updatable.Update();
		}
	}
}