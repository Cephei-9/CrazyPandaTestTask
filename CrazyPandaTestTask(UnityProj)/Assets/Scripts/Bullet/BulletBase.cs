using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrazyPandaTestTask;
using UnityEngine;

namespace DefaultNamespace
{
	public abstract class BulletBase<TData> : MonoBehaviour, IInitializeBullet<TData>
	{
		[SerializeField]
		private BulletViewBase[] Views;
		
		public event Action DestroyEvent;

		protected TData _data;
		protected bool _beginDestroy;

		public virtual void InitData(TData data)
		{
			_data = data;
		}

		private void OnCollisionEnter2D(Collision2D col)
		{
			OnBulletCollision(col);
		}

		public virtual void Prewarm()
		{
			ForeachViews(v => v.Prewarm());
		}

		public virtual void Shoot(Vector2 velocity, ITimeProvider timeProvider)
		{
			ForeachViews(v =>
			{
				v.InitTimeProvider(timeProvider);
				v.Shoot();
			});
		}

		protected virtual void OnBulletCollision(Collision2D col)
		{
			ForeachViews(v => v.Collision(col));
		}

		public virtual async Task DestroyBullet()
		{
			if (_beginDestroy)
				return;
			
			_beginDestroy = true;
			
			IEnumerable<Task> viewsDestroyTasks = Views.Select(v => v.Destroy());
			await Task.WhenAll(viewsDestroyTasks);
			
			InvokeDestroyEvent();
		}

		private void ForeachViews(Action<BulletViewBase> action)
		{
			foreach (BulletViewBase view in Views)
			{
				action.Invoke(view);
			}
		}

		protected void InvokeDestroyEvent()
		{
			DestroyEvent?.Invoke();
		}
	}
}