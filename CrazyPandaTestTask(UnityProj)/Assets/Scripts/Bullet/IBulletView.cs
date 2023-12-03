using System.Threading.Tasks;
using CrazyPandaTestTask;
using UnityEngine;

namespace DefaultNamespace
{
	public interface IBulletView
	{
		void InitTimeProvider(ITimeProvider timeProvider);
		
		void Prewarm();

		void Shoot();

		void Collision(Collision2D collision2D);

		Task Destroy();
	}
}