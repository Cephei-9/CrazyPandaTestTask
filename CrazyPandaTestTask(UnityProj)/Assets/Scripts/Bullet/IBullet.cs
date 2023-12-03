using System;
using System.Threading.Tasks;
using CrazyPandaTestTask;
using UnityEngine;

namespace DefaultNamespace
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