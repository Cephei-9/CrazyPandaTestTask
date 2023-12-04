using CrazyPandaTestTask.BulletComponents;
using CrazyPandaTestTask.ChronoArea;
using CrazyPandaTestTask.Engine;
using CrazyPandaTestTask.Time;
using UnityEngine;

namespace CrazyPandaTestTask.Bullet
{
	public class GhostBullet : BulletBase<BulletData>
	{
		[SerializeField]
		private ChronoObject ChronoObject;
		[SerializeField]
		private ColorTimeScaleView TimeScaleView;

		private TransformChronoEngine _engine;
		
		public override void Shoot(Vector2 velocity, ITimeProvider timeProvider)
		{
			ChronoObject.Init(timeProvider);
			TimeScaleView.Init(ChronoObject);

			_engine = new TransformChronoEngine(ChronoObject, timeProvider, _data.EngineData, transform);
			_engine.AddChronoForce(velocity * _data.ShootVelocityMultiply, ForceMode.VelocityChange);
			
			base.Shoot(velocity, timeProvider);
		}

		private void Update()
		{
			_engine.UpdateWork();
		}
	}
}