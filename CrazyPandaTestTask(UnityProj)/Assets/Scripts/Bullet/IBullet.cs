using System;
using System.Threading.Tasks;
using CrazyPandaTestTask.Time;
using UnityEngine;

namespace CrazyPandaTestTask.Bullet
{
	public interface IInitializeBullet<TData> : IBullet
	{
		void InitData(TData data);
	}

	public interface IBullet
	{
		event Action DestroyEvent;

		void Prewarm();

		void Shoot(Vector2 velocity, ITimeProvider timeProvider);

		Task DestroyBullet();
	}
}