using System;
using CrazyPandaTestTask;
using UnityEngine;

namespace DefaultNamespace
{
	public interface IChronoEngine
	{
		[Serializable]
		public class Data
		{
			public bool UseDefaultGravity = true;
			public float Gravity = 10;
			public float Drag = 0;
		}

		Vector2 Velocity { get; set; }
		
		void AddForce(Vector2 force, ForceMode forceMode = ForceMode.Force);
		
		void AddChronoForce(Vector2 force, ForceMode forceMode = ForceMode.Force);

		// Вроде бы физически корректно перевожу силу в скорость, но нет времени чтобы это прям хорошо обдумать и тестить
		protected static Vector2 ConvertForceToVelocity(Vector2 force, ForceMode forceMode, float deltaTime, float mass,
			float chronoFactor)
		{
			float forceModeFactor = 1;

			if (forceMode is ForceMode.Acceleration or ForceMode.Force)
				forceModeFactor *= deltaTime;
			if (forceMode is ForceMode.Impulse or ForceMode.Force)
				forceModeFactor /= mass;

			return force * (forceModeFactor * chronoFactor);
		}
	}

	// Интерфейс нужен чтобы управляющий код понимал как работать с реализацией в Update или FixedUpdate
	public interface ITransformChronoEngine : IChronoEngine
	{
		
	}

	// Можно также придумать реализацию для киниматик движения с движением через MovePosition
	public interface IPhysicChronoEngine : IChronoEngine
	{
		
	}
}