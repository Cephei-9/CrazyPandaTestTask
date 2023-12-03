using CrazyPandaTestTask;
using DefaultNamespace.Engine;
using DefaultNamespace.Runtime;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
	public class Bullet : MonoBehaviour
	{
		public IChronoEngine.Data EngineData;
		[FormerlySerializedAs("TimeWrapObject")]
		public ChronoObject ChronoObject;

		private TransformChronoEngine _engine;

		private IUpdatable[] _updatable;

		private void Awake()
		{
			ChronoObject.Init(ITimeProvider.Default);
			_engine = new TransformChronoEngine(ChronoObject, ITimeProvider.Unscaled, EngineData, transform);
			_updatable = new IUpdatable[] { _engine };
		}

		public void Shoot(Vector2 velocity)
		{
			_engine.AddChronoForce(velocity, ForceMode.VelocityChange);	
		}

		private void Update()
		{
			_updatable.Update();
		}
	}
}