using CrazyPandaTestTask.BulletComponents;
using CrazyPandaTestTask.ChronoArea;
using CrazyPandaTestTask.Engine;
using CrazyPandaTestTask.Time;
using CrazyPandaTestTask.Tools;
using UnityEngine;

namespace CrazyPandaTestTask.Bullet
{
	public class GhostBullet : BulletBase<BulletData>
	{
		[SerializeField]
		private ChronoObjectCollider ChronoCollider;
		[SerializeField]
		private ColorTimeScaleView TimeScaleView;

		private TransformChronoEngine _engine;
		private ChronoObject _chronoObject;
		
		private IUpdatable[] _updatable;
		
		public override void Shoot(Vector2 velocity, ITimeProvider timeProvider)
		{
			_chronoObject = new ChronoObject(timeProvider, transform);
			
			ChronoCollider.Init(_chronoObject);
			TimeScaleView.Init(_chronoObject);

			_engine = new TransformChronoEngine(_chronoObject, timeProvider, _data.EngineData, transform);
			_engine.AddChronoForce(velocity * _data.ShootVelocityMultiply, ForceMode.VelocityChange);

			_updatable = new IUpdatable[]
			{
				_chronoObject,
				_engine
			};
			
			base.Shoot(velocity, timeProvider);
		}

		private void Update()
		{
			_updatable.Update();
		}
	}
}