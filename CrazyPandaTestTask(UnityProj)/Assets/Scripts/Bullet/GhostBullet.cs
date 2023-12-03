using CrazyPandaTestTask;
using DefaultNamespace.BulletComponents;
using DefaultNamespace.Engine;
using UnityEngine;

namespace DefaultNamespace
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