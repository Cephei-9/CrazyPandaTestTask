using System.Threading.Tasks;
using CrazyPandaTestTask.Time;
using UnityEngine;

namespace CrazyPandaTestTask.Bullet
{
	public abstract class BulletViewBase : MonoBehaviour, IBulletView
	{
		public abstract void InitTimeProvider(ITimeProvider timeProvider);

		public abstract void Prewarm();

		public abstract void Shoot();

		public abstract void Collision(Collision2D collision2D);

		public abstract Task Destroy();
	}
}