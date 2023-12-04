using CrazyPandaTestTask.Time;
using CrazyPandaTestTask.Tools;
using UnityEngine;

namespace CrazyPandaTestTask.Engine
{
	public class PhysicsChronoEngine : ChronoEngineBase, IFixedUpdatable
	{
		private Rigidbody2D _rb;
		private float _startMass;
		
		private new float _previousTimeScale;

		public override Vector2 Velocity { get; set; }

		public PhysicsChronoEngine(ITimeProvider targetProvider, ITimeProvider unscaledProvider,
			IChronoEngine.Data data, Rigidbody2D rb) : base(targetProvider, unscaledProvider, data)
		{
			_rb = rb;
			_startMass = _rb.mass;
			_previousTimeScale = _targetProvider.TimeScale;
		}

		public void UpdateWork()
		{
			UpdateGravityValue();
			AddDrag();
			AddGravity();
			ApplyVelocity();
				
			_previousTimeScale = _targetProvider.TimeScale;
		}

		public void OnCollision()
		{
			Vector2 collisionVelocityDelta = _rb.velocity - Velocity * _previousTimeScale;
			Velocity += collisionVelocityDelta / _previousTimeScale;
		}

		private void ApplyVelocity()
		{
			_rb.velocity = Velocity * _targetProvider.TimeScale;
			_rb.mass = Mathf.Sqrt(_startMass / _targetProvider.TimeScale);
		}

		public override void AddForce(Vector2 force, ForceMode forceMode = ForceMode.Force)
		{
			Velocity +=
				IChronoEngine.ConvertForceToVelocity(force, forceMode, _unscaledProvider.FixedDeltaTime, _rb.mass, 1);
		}

		public override void AddChronoForce(Vector2 force, ForceMode forceMode = ForceMode.Force)
		{
			Velocity +=
				IChronoEngine.ConvertForceToVelocity(force, forceMode, _targetProvider.FixedDeltaTime, _rb.mass,
					1);
		}
	}
}