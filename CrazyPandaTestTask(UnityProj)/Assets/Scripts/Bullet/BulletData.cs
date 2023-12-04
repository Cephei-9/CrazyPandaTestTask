using System;
using CrazyPandaTestTask.Engine;

namespace CrazyPandaTestTask.Bullet
{
	[Serializable]
	public class BulletData
	{
		public float ShootVelocityMultiply = 1;
		public IChronoEngine.Data EngineData;
	}
}