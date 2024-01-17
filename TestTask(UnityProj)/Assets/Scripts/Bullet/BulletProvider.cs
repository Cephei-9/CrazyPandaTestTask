using System;

namespace Bullet
{
	[Serializable]
	public class BulletProvider<T>
	{
		public T SimpleBullet;
		public T GhostBullet;
		public T InvertBullet;
		public T ChaoticBullet;

		public T GetBullet(BulletType type)
		{
			T returnedValue = type switch
			{
				BulletType.Simple => SimpleBullet,
				BulletType.Ghost => GhostBullet,
				BulletType.Invert => InvertBullet,
				BulletType.Chaotic => ChaoticBullet,
				_ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
			};

			return returnedValue;
		}	
	}
}