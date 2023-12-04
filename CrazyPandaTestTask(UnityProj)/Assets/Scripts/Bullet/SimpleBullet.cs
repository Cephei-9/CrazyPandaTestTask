using CrazyPandaTestTask.ChronoArea;
using CrazyPandaTestTask.Engine;
using CrazyPandaTestTask.Time;
using UnityEngine;

namespace CrazyPandaTestTask.Bullet
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class SimpleBullet : BulletBase<BulletData>
	{
		[SerializeField]
		private ChronoObject ChronoObject;

		private PhysicsChronoEngine _engine;
		
		public override void Shoot(Vector2 velocity, ITimeProvider timeProvider)
		{
			ChronoObject.Init(timeProvider);
			
			Rigidbody2D rb = GetComponent<Rigidbody2D>();
			_engine = new PhysicsChronoEngine(ChronoObject, timeProvider, _data.EngineData, rb);
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