using CrazyPandaTestTask.Time;
using CrazyPandaTestTask.Tools;
using UnityEngine;

namespace CrazyPandaTestTask.Engine
{
	public class PhysicsChronoEngine : ChronoEngineBase, IFixedUpdatable
	{
		private const float MAX_RB_MASS = float.MaxValue;
		
		private Rigidbody2D _rb;
		private float _startMass;
		
		private float _previousTimeScale;

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
			float clampedTimeScale = Mathf.Max(_targetProvider.TimeScale, Mathf.Epsilon);
			float timeScaledMass = _startMass / clampedTimeScale;
			float clampedMass = Mathf.Min(timeScaledMass, MAX_RB_MASS);
   
   			_rb.mass = clampedMass;
			_rb.velocity = Velocity * _targetProvider.TimeScale;
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
