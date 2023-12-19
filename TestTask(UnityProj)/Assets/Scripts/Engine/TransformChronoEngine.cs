using Time.Infrastructure;
using Tools;
using UnityEngine;

namespace Engine
{
	public class TransformChronoEngine : ChronoEngineBase, ITransformChronoEngine, IUpdatable
	{
		private Transform _transform;

		public TransformChronoEngine(ITimeProvider targetProvider, ITimeProvider unscaledProvider,
			IChronoEngine.Data data, Transform transform) : base(targetProvider, unscaledProvider, data)
		{
			_transform = transform;
		}

		public override Vector2 Velocity { get; set; }

		public void UpdateWork()
		{
			UpdateGravityValue();
			AddDrag();
			AddGravity();
			ApplyVelocity();
		}

		public override void AddForce(Vector2 force, ForceMode forceMode = ForceMode.Force)
		{
			Velocity +=
				IChronoEngine.ConvertForceToVelocity(force, forceMode, _unscaledProvider.DeltaTime, 1, 1);
		}

		public override void AddChronoForce(Vector2 force, ForceMode forceMode = ForceMode.Force)
		{
			Velocity +=
				IChronoEngine.ConvertForceToVelocity(force, forceMode, _targetProvider.DeltaTime, 1, 1);
		}

		private void ApplyVelocity()
		{
			_transform.position += (Vector3)Velocity * _targetProvider.DeltaTime;
		}
	}
}