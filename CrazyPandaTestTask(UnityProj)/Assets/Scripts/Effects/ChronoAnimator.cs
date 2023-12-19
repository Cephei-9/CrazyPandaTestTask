using Time.Infrastructure;
using UnityEngine;

namespace Effects
{
	public class ChronoAnimator : BaseChronoEffect
	{
		private Animator _animator;

		public ChronoAnimator(Animator animator, ITimeProvider timeProvider) : base(timeProvider)
		{
			_animator = animator;
			
			BakeVelocity();
			UpdateVelocityByTimeScale();
		}

		public override float Velocity
		{
			get => _animator.speed;
			set => _animator.speed = value;
		}
	}
}