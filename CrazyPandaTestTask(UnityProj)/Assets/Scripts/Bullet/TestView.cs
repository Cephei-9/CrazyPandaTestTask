using System.Collections;
using System.Threading.Tasks;
using CrazyPandaTestTask;
using UnityEngine;

namespace DefaultNamespace
{
	public class TestView : BulletViewBase
	{
		[SerializeField]
		private int Delay = 1;

		private TaskCompletionSource<Task> _destroyCompletionSource;

		public override void InitTimeProvider(ITimeProvider timeProvider)
		{
			
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
			_destroyCompletionSource = new TaskCompletionSource<Task>();
			StartCoroutine(SomeRoutine());
			await _destroyCompletionSource.Task;
		}

		private IEnumerator SomeRoutine()
		{
			yield return new WaitForSeconds(Delay);
			_destroyCompletionSource.SetResult(Task.CompletedTask);
		}
	}
}