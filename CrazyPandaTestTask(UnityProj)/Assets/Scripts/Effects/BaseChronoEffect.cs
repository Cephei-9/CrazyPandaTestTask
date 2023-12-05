using CrazyPandaTestTask.Time;

namespace CrazyPandaTestTask.Effects
{
	// Base class that implements the logic of speed switching according to TimeProvider. It is suitable for Animator,
	// AudioSource and ParticleSystem
	
	// Working with effects is a delicate thing, and I just realized them in the context of time
	// mechanics and allocated a convenient wrapper for it. Of course the actual infrastructure for effects should be
	// written smarter and for a specific project
	
	public abstract class BaseChronoEffect
	{
		protected ITimeProvider _timeProvider;
		
		public float BakedVelocity { get; set; }
		public abstract float Velocity { get; set; }

		public BaseChronoEffect(ITimeProvider timeProvider)
		{
			_timeProvider = timeProvider;
			_timeProvider.ChangeTimeScaleEvent += OnChangeTimeScale;
		}

		public virtual void OnDestroy()
		{
			_timeProvider.ChangeTimeScaleEvent -= OnChangeTimeScale;
		}

		public void BakeVelocity()
		{
			BakedVelocity = Velocity;
		}

		public void UpdateVelocityByTimeScale()
		{
			Velocity = BakedVelocity * _timeProvider.TimeScale;
		}

		public void SetBakedVelocity(float newBakedVelocity)
		{
			BakedVelocity = newBakedVelocity;
			Velocity = BakedVelocity * _timeProvider.TimeScale;
		}

		protected virtual void OnChangeTimeScale(float previousTimeScale, float nextScale)
		{
			UpdateVelocityByTimeScale();
		}
	}
}