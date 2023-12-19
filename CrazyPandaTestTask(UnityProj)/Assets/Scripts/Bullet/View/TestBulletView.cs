using System.Collections;
using System.Threading.Tasks;
using Time.Infrastructure;
using UnityEngine;

namespace Bullet.View
{
	public class TestBulletView : BulletViewBase
	{
		[SerializeField]
		private int Delay = 1;

		private ITimeProvider _timeProvider;

		public override void InitTimeProvider(ITimeProvider timeProvider)
		{
			_timeProvider = timeProvider;
		}

		public override void Prewarm()
		{
			
		}

		public override void Shoot()
		{
			
		}

		public override void Collision(Collision2D collision2D)
		{
			
		}

		public override async Task Destroy()
		{
			TaskCompletionSource<Task> completionSource = new();
			StartCoroutine(SomeRoutine(completionSource));
			await completionSource.Task;
		}

		// Use coroutine to use _timeProvider.Delta time in runtime
		private IEnumerator SomeRoutine(TaskCompletionSource<Task> taskCompletionSource)
		{
			float timer = 0;
				
			while (timer < Delay)
			{
				timer += _timeProvider.DeltaTime;
				yield return null;
			}
			taskCompletionSource.SetResult(Task.CompletedTask);
		}
	}
}