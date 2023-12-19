using System;
using System.Threading.Tasks;
using Time.Infrastructure;
using UnityEngine;

namespace Bullet
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