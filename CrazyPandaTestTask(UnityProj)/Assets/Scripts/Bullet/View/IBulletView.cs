using System.Threading.Tasks;
using CrazyPandaTestTask.Time;
using UnityEngine;

namespace CrazyPandaTestTask.Bullet.View
{
	// In reality, the Bulet View interface should be more complex and elaborate, there should be passed there what
	// parameters, etc.
	
	public interface IBulletView
	{
		void InitTimeProvider(ITimeProvider timeProvider);
		
		void Prewarm();

		void Shoot();

		void Collision(Collision2D collision2D);

		Task Destroy();
	}
}