using CrazyPandaTestTask;
using DefaultNamespace.Runtime;
using UnityEngine;

namespace DefaultNamespace
{
	public class PhysicsChronoEngine : ChronoEngineBase, IFixedUpdatable
	{
		private Rigidbody2D _rb;

		public override Vector2 Velocity
		{
			get => _rb.velocity;
			set => _rb.velocity = value;
		}
		
		public void UpdateWork()
		{
			UpdateGravity();
			HandleTimeScaleChanging();
			AddDrag();
			AddGravity();
		}

		public PhysicsChronoEngine(ITimeProvider targetProvider, ITimeProvider unscaledProvider,
			IChronoEngine.Data data, Rigidbody2D rb) : base(targetProvider, unscaledProvider, data)
		{
			_rb = rb;
			UpdateMass(targetProvider.TimeScale);
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
					_targetProvider.TimeScale);
		}

		private void HandleTimeScaleChanging()
		{
			if (!CheckChangeTimeScale(out float scaleDiff)) 
				return;

			Velocity *= scaleDiff;
			_rb.mass /= scaleDiff;
		}

		private void UpdateMass(float scaleDelta)
		{
			_rb.mass /= scaleDelta;
		}
	}
}