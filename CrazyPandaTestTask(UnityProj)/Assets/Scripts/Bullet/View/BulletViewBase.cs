using System.Threading.Tasks;
using CrazyPandaTestTask.Time;
using UnityEngine;

namespace CrazyPandaTestTask.Bullet.View
{
	// In reality, the Bulet View interface should be more complex and elaborate, there should be passed there what
	// parameters, etc.
	
	public abstract class BulletViewBase : MonoBehaviour, IBulletView
	{
		public virtual void InitTimeProvider(ITimeProvider timeProvider) { }

		public virtual void Prewarm() { }

		public virtual void Shoot() { }

		public virtual void Collision(Collision2D collision2D) { }

		public virtual Task Destroy() => Task.CompletedTask;
	}
}