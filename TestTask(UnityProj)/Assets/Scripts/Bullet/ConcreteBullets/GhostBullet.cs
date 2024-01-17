using System.Threading.Tasks;
using Bullet.BulletComponents;
using Chrono;
using Engine;
using Time.Infrastructure;
using Tools;
using UnityEngine;

namespace Bullet.ConcreteBullets
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
			
			base.Shoot(velocity, _chronoObject);
		}

		public override Task DestroyBullet()
		{
			// Need to add functionality to turn off Engine
			_engine.Velocity = Vector2.zero;
			return base.DestroyBullet();
		}

		private void Update()
		{
			_updatable.Update();
		}
	}
}