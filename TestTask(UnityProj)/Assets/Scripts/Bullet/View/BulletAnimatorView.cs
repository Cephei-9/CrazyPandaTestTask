using System.Threading.Tasks;
using Effects;
using Time.Infrastructure;
using UnityEngine;

namespace Bullet.View
{
	public class BulletAnimatorView : BulletViewBase
	{
		private const float DESTROY_ANIMATION_DEADLINE = 10;
		
		private static readonly int _destroyTrigger = Animator.StringToHash("Destroy");
		private static readonly int _rotateTrigger = Animator.StringToHash("Rotate");
		private static readonly int _collisionTrigger = Animator.StringToHash("Collision");
		private static readonly int _collisionAnimationStateName = Animator.StringToHash("CollisionBulletAnim");

		[SerializeField]
		private Animator Animator;

		private ChronoAnimator _chronoAnimator;
		private TaskCompletionSource<Task> _completionSource;

		private bool _destroy;

		public override void InitTimeProvider(ITimeProvider timeProvider)
		{
			_chronoAnimator = new ChronoAnimator(Animator, timeProvider);
		}

		public override void Shoot()
		{
			Animator.SetTrigger(_rotateTrigger);
		}

		public override void Collision(Collision2D collision2D)
		{
			AnimatorStateInfo stateInfo = Animator.GetCurrentAnimatorStateInfo(0);
			if(stateInfo.shortNameHash != _collisionAnimationStateName)
				Animator.SetTrigger(_collisionTrigger);
		}

		public void OnAnimationDestroyEvent()
		{
			_completionSource.SetResult(Task.CompletedTask);
		}

		public override async Task Destroy()
		{
			_destroy = true;
			
			await AwaitAnimation();

			_chronoAnimator.OnDestroy();
		}

		private async Task AwaitAnimation()
		{
			Animator.SetTrigger(_destroyTrigger);
			_completionSource = new TaskCompletionSource<Task>();
			Task deadlineDelay = Task.Delay((int)(DESTROY_ANIMATION_DEADLINE * 1000));

			await Task.WhenAny(_completionSource.Task, deadlineDelay);
		}
	}
}