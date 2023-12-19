using System;
using Engine;

namespace Bullet
{
	[Serializable]
	public class BulletData
	{
		public float ShootVelocityMultiply = 1;
		public IChronoEngine.Data EngineData;
	}
}