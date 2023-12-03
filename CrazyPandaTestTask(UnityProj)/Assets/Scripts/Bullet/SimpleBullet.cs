using CrazyPandaTestTask;
using UnityEngine;

namespace DefaultNamespace
{
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

		private void FixedUpdate()
		{
			_engine.UpdateWork();
		}
	}
}