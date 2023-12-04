using CrazyPandaTestTask;
using UnityEngine;

namespace DefaultNamespace
{
	// Нужен чтобы можно было использовать в инспекторе как базовый класс
	public abstract class ChronoEngineBase : IChronoEngine
	{
		public abstract Vector2 Velocity { get; set; }

		protected ITimeProvider _targetProvider;
		protected ITimeProvider _unscaledProvider;
		protected IChronoEngine.Data _data;
		
		protected float _gravity;

		protected ChronoEngineBase(ITimeProvider targetProvider, ITimeProvider unscaledProvider, IChronoEngine.Data data)
		{
			_targetProvider = targetProvider;
			_unscaledProvider = unscaledProvider;
			_data = data;
			
			UpdateGravityValue();
		}
		
		public abstract void AddForce(Vector2 force, ForceMode forceMode = ForceMode.Force);

		public abstract void AddChronoForce(Vector2 force, ForceMode forceMode = ForceMode.Force);

		protected void AddGravity()
		{
			Vector2 gravity = Vector2.down * _gravity;
			AddChronoForce(gravity, ForceMode.Acceleration);
		}

		protected void AddDrag()
		{
			Vector2 dragAcceleration = Velocity * (-1 * _data.Drag);
			AddChronoForce(dragAcceleration, ForceMode.Acceleration);
		}

		protected void UpdateGravityValue()
		{
			_gravity = _data.UseDefaultGravity ? Physics2D.gravity.magnitude : _data.Gravity;
		}
	}
}