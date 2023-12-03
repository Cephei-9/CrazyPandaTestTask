using UnityEngine;

namespace DefaultNamespace.Factory
{
	[CreateAssetMenu(fileName = "BulletConfig", menuName = "BulletConfig", order = 51)]
	public class BulletConfigs : ScriptableObject
	{
		public BulletConfig<SimpleBullet, BulletData> SimpleBullet;
		public BulletConfig<InvertBullet, InvertBullet.Data> InvertBullet;
		public BulletConfig<GhostBullet, BulletData> GhostBullet;
		public BulletConfig<ChaoticBullet, ChaoticBullet.Data> ChaoticBullet;
	}
}